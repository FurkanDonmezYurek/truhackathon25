﻿using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using Firebase.Firestore;
using System.Collections.Generic;

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    FirebaseFirestore db;

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp
            .CheckAndFixDependenciesAsync()
            .ContinueWith(task =>
            {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    // Firebase başlatılıyor
                    auth = FirebaseAuth.DefaultInstance;

                    db = FirebaseFirestore.DefaultInstance;
                    Debug.Log("Firebase başarıyla başlatıldı.");
                    // s();
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus
                    );
                }
            });
    }

    public void s()
    {
        // "list" koleksiyonuna referans alıyoruz
        CollectionReference data = db.Collection("memberlist");

        // Koleksiyondaki tüm belgeleri alıyoruz
        data.GetSnapshotAsync()
            .ContinueWith(async task =>
            {
                if (task.IsCompleted)
                {
                    Query query = data.OrderBy("userName");
                    // Koleksiyondaki tüm belgeler burada
                    QuerySnapshot snapshot = await query.GetSnapshotAsync();

                    // Her bir belgeyi döngü ile okuyoruz
                    foreach (DocumentSnapshot document in snapshot.Documents)
                    {
                        // Verileri Dictionary olarak alıyoruz
                        Dictionary<string, object> Data = document.ToDictionary();

                        // Verileri kontrol edip Product nesnesine dönüştürüyoruz
                        if (
                            Data.ContainsKey("userName")
                            && Data.ContainsKey("status")
                            && Data.ContainsKey("calibration")
                            && Data.ContainsKey("hasCurrentTask")
                            && Data.ContainsKey("bestScore")
                            && Data.ContainsKey("bestTime")
                        )
                        {
                            if (Data["userName"].ToString() == User.DisplayName)
                            {
                                string userName = Data["userName"].ToString();
                                string status = Data["status"].ToString();
                                float calibration = float.Parse(Data["calibration"].ToString());
                                string hasCurrentTask = Data["hasCurrentTask"].ToString();
                                string bestScore = Data["bestScore"].ToString();
                                string bestTime = Data["bestScore"].ToString();

                                Debug.Log(
                                    userName
                                        + status
                                        + calibration
                                        + hasCurrentTask
                                        + bestScore
                                        + bestTime
                                );
                            }
                            else
                            {
                                SaveData("sa", "sa", 12f, "sa", "sa", "gfr");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("Veri okunurken bir hata oluştu: " + task.Exception);
                }
            });
    }

    public void SaveData(
        string userName,
        string status,
        float calibration,
        string hasCurrentTask,
        string bestScore,
        string bestTime
    )
    {
        DocumentReference docRef = db.Collection("memberlist").Document(name);
        Dictionary<string, object> Data = new Dictionary<string, object>
        {
            { "userName", userName },
            { "status", status },
            { "calibration", calibration.ToString() },
            { "hasCurrentTask", hasCurrentTask },
            { "bestScore", bestScore },
            { "bestTime", bestTime }
        };

        docRef
            .SetAsync(Data)
            .ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Data saved to Firestore.");
                }
                else
                {
                    Debug.LogError("Error saving data: " + task.Exception);
                }
            });
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }

    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(
            Register(
                emailRegisterField.text,
                passwordRegisterField.text,
                usernameRegisterField.text
            )
        );
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        Task<AuthResult> LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);
        Debug.Log(_email + _password);
        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx =
                LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            Task<AuthResult> RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(
                _email,
                _password
            );
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx =
                    RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result.User;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    Task ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(
                            message: $"Failed to register task with {ProfileTask.Exception}"
                        );
                        FirebaseException firebaseEx =
                            ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        // UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                    }
                }
            }
        }
    }
}
