using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Firebase;
using Firebase.Auth;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Container;

    FirebaseFirestore db;

    public FirebaseAuth auth;
    public FirebaseUser User;

    [SerializeField]
    public List<Tasks> taskList = new List<Tasks>();
    public GameObject taskPref;

    void Start()
    {
        FirebaseApp
            .CheckAndFixDependenciesAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    auth = FirebaseAuth.DefaultInstance;
                    db = FirebaseFirestore.DefaultInstance;
                    listTask("tasklist");
                }
                else
                {
                    Debug.LogError("Firebase bağımlılıkları eksik: " + task.Result);
                }
            });
    }

    public void listTask(string listTasks)
    {
        db.Collection(listTasks)
            .GetSnapshotAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Belge alınırken hata oluştu: " + task.Exception);
                    return;
                }

                QuerySnapshot belgeSnap = task.Result;
                bool findDoc = false;
                int i = 1;
                foreach (DocumentSnapshot document in belgeSnap.Documents)
                {
                    if (document.Id == User.DisplayName)
                    {
                        findDoc = true;
                        // Verileri Dictionary olarak alıyoruz
                        Dictionary<string, object> Data = document.ToDictionary();

                        while (Data[$"task#{i}"].ToString() != "")
                        {
                            string text = Data[$"task#{i}"].ToString();
                            string[] anan = text.Split(char.Parse("-"));
                            Tasks newTasks = new Tasks(
                                i.ToString(),
                                anan[0],
                                anan[1],
                                anan[2],
                                anan[3],
                                anan[4]
                            );
                            i++;
                            if (!taskList.Contains(newTasks))
                            {
                                taskList.Add(newTasks);
                            }
                        }
                    }
                }
                if (findDoc == false)
                {
                    // gameStartMenu.ConfigurationMenu();
                }
            });
    }

    public void AddTask()
    {
        foreach (var item in taskList)
        {
            GameObject currentItem = Instantiate(
                taskPref,
                taskPref.transform.position,
                Quaternion.identity
            );
            currentItem.transform.SetParent(Container.transform);
            currentItem.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text =
                "#" + item.Count;
            currentItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text =
                item.Level;
            currentItem.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text =
                item.Score;
            currentItem.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text =
                item.AppleCount;
            currentItem.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text =
                item.Timer;
        }
    }
}
