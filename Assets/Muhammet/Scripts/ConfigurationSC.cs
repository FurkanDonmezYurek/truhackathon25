//////using TMPro;
//////using UnityEngine;
//////using UnityEngine.InputSystem;
//////using UnityEngine.XR;

//////public class ConfigurationSC : MonoBehaviour
//////{
//////    public Vector3 frontMaxDistanceRighthand;
//////    public Vector3 UpMaxDistanceRighthand;
//////    public Vector3 RightMaxDistanceRighthand;
//////    public Vector3 LeftMaxDistanceRighthand;


//////    Vector3 horizontalCenter;
//////    Vector3 verticalCenter;
//////    Vector3 shoulderPosition;

//////    private bool previousPressedState = false;

//////    public TextMeshProUGUI infoText;

//////    private float _lastStepUpTime;

//////    private int _step = 0;
//////    void Update()
//////    {
//////        infoText.text = "Sag Kontrolcude A tusuna Bas";
//////        UnityEngine.XR.InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
//////        bool isPressed;
//////        if (_step == 1)
//////        {

//////        }
//////        else if (_step == 2)
//////        {

//////        }
//////        else if (_step == 3)
//////        {

//////        }
//////        else if (_step == 4)
//////        {

//////        }


//////        if (rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out isPressed))
//////        {
//////            if (isPressed && !previousPressedState)
//////            {
//////                Debug.Log("A tusuna BASILDI (ilk an)");
//////                if (_lastStepUpTime - Time.time >= 3)
//////                {
//////                    _lastStepUpTime = Time.time;
//////                    _step++;
//////                    if (_step == 1)
//////                    {
//////                        infoText.text = "Elini olabildigince ileri gotur";

//////                    }
//////                    else if (_step == 2)
//////                    {
//////                        infoText.text = "Elini olabildigince yukari gotur";
//////                    }
//////                    else if (_step == 3)
//////                    {
//////                        infoText.text = "Elini olabildigince Saga gotur";
//////                    }
//////                    else if (_step == 4)
//////                    {
//////                        infoText.text = "Elini olabildigince Sola gotur";

//////                    }
//////                    else if (_step == 5)
//////                    {
//////                        Vector3 horizontalCenter = (RightMaxDistanceRighthand + LeftMaxDistanceRighthand) / 2f;
//////                        Vector3 verticalCenter = (UpMaxDistanceRighthand + frontMaxDistanceRighthand) / 2f;
//////                        Vector3 shoulderPosition = (horizontalCenter + verticalCenter) / 2f;

//////                        infoText.text = "Tebrik ederim tum adimlari tamamladin !!";
//////                        Invoke("GoMainMenu",1f);
//////                    }
//////                }

//////            }

//////            previousPressedState = isPressed;
//////        }
//////    }

//////    private void CreateColldier()
//////    {
//////        GameObject shoulderColliderObj = new GameObject("ShoulderReachCollider");
//////        shoulderColliderObj.transform.position = shoulderPosition;
//////        shoulderColliderObj.transform.parent = transform; // karaktere bagla

//////        SphereCollider sphere = shoulderColliderObj.AddComponent<SphereCollider>();
//////        sphere.isTrigger = true;

//////        // Cap (yaricap) tahmini: ortalama mesafe kullanabilirsin
//////        float radius = Vector3.Distance(shoulderPosition, frontMaxDistanceRighthand);
//////        sphere.radius = radius;
//////    }

//////    public void GoMainMenu()
//////    {
//////        SceneTransitionManager.singleton.GoToSceneAsync(0);
//////    }
//////}



////using TMPro;
////using UnityEngine;
////using UnityEngine.XR;

////public class ConfigurationSC : MonoBehaviour
////{
////    public Vector3 frontMaxDistanceRighthand;
////    public Vector3 UpMaxDistanceRighthand;
////    public Vector3 RightMaxDistanceRighthand;
////    public Vector3 LeftMaxDistanceRighthand;

////    private Vector3 shoulderPosition;

////    private bool previousPressedState = false;
////    private float _lastStepUpTime;
////    private int _step = 0;

////    public TextMeshPro infoText;
////    public Transform shoulderReference;

////    private float maxDistance = 0f;
////    private Vector3 maxPosition = Vector3.zero;

////    void Update()
////    {
////        infoText.text = "Sag Kontrolcude A tusuna Bas";
////        UnityEngine.XR.InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

////        // Su anki el pozisyonu
////        if (rightHand.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentHandPos))
////        {
////            if (_step == 1 || _step == 2 || _step == 3 || _step == 4)
////            {
////                float distance = Vector3.Distance(shoulderReference.position, currentHandPos);
////                if (distance > maxDistance)
////                {
////                    maxDistance = distance;
////                    maxPosition = currentHandPos;
////                }
////            }
////        }

////        // A tusuna basma kontrolü
////        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
////        {
////            if (isPressed && !previousPressedState)
////            {
////                Debug.Log("A tusuna BASILDI (ilk an)");
////                if (Time.time - _lastStepUpTime >= 3)
////                {
////                    _lastStepUpTime = Time.time;
////                    _step++;

////                    // Olcum kaydi
////                    if (_step == 1)
////                    {
////                        maxDistance = 0f;
////                        infoText.text = "Elini olabildigince ileri gotur";
////                    }
////                    else if (_step == 2)
////                    {
////                        frontMaxDistanceRighthand = maxPosition;
////                        maxDistance = 0f;
////                        infoText.text = "Elini olabildigince yukari gotur";
////                    }
////                    else if (_step == 3)
////                    {
////                        UpMaxDistanceRighthand = maxPosition;
////                        maxDistance = 0f;
////                        infoText.text = "Elini olabildigince Saga gotur";
////                    }
////                    else if (_step == 4)
////                    {
////                        RightMaxDistanceRighthand = maxPosition;
////                        maxDistance = 0f;
////                        infoText.text = "Elini olabildigince Sola gotur";
////                    }
////                    else if (_step == 5)
////                    {
////                        LeftMaxDistanceRighthand = maxPosition;

////                        Vector3 horizontalCenter = (RightMaxDistanceRighthand + LeftMaxDistanceRighthand) / 2f;
////                        Vector3 verticalCenter = (UpMaxDistanceRighthand + frontMaxDistanceRighthand) / 2f;
////                        shoulderPosition = (horizontalCenter + verticalCenter) / 2f;

////                        CreateColldier();
////                        infoText.text = "Tebrik ederim tum adimlari tamamladin !!";
////                        Invoke("GoMainMenu", 1f);
////                    }
////                }
////            }

////            previousPressedState = isPressed;
////        }
////    }

////    private void CreateColldier()
////    {
////        GameObject shoulderColliderObj = new GameObject("ShoulderReachCollider");
////        shoulderColliderObj.transform.position = shoulderPosition;
////        shoulderColliderObj.transform.parent = transform;

////        SphereCollider sphere = shoulderColliderObj.AddComponent<SphereCollider>();
////        sphere.isTrigger = true;

////        float averageRadius = (
////            Vector3.Distance(shoulderPosition, frontMaxDistanceRighthand) +
////            Vector3.Distance(shoulderPosition, UpMaxDistanceRighthand) +
////            Vector3.Distance(shoulderPosition, RightMaxDistanceRighthand) +
////            Vector3.Distance(shoulderPosition, LeftMaxDistanceRighthand)
////        ) / 4f;

////        sphere.radius = averageRadius;
////    }

////    public void GoMainMenu()
////    {
////        SceneTransitionManager.singleton.GoToSceneAsync(0);
////    }
////}


//using TMPro;
//using UnityEngine;
//using UnityEngine.XR;

//public class ConfigurationSC : MonoBehaviour
//{
//    public Transform shoulderReference;       // Omuz noktasýný temsil eden referans Transform
//    public TextMeshProUGUI infoText;

//    // Ölçülen en uç noktalar
//    public Vector3 frontMaxDistanceRighthand;
//    public Vector3 upMaxDistanceRighthand;
//    public Vector3 rightMaxDistanceRighthand;
//    public Vector3 leftMaxDistanceRighthand;

//    // Yön baþýna ayrý ayrý saklayacaðýmýz en büyük mesafeler
//    private float maxFrontDist = 0f;
//    private float maxUpDist = 0f;
//    private float maxRightDist = 0f;
//    private float maxLeftDist = 0f;

//    private bool previousPressedState = false;
//    private float _lastStepUpTime = 0f;
//    private int _step = 0;

//    void Update()
//    {
//        // Ýlk olarak her frame’da güncellenen el pozisyonunu al
//        UnityEngine.XR.InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
//        if (rightHand.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 handPos))
//        {
//            Vector3 diff = handPos - shoulderReference.position;

//            switch (_step)
//            {
//                case 1: // 1. adým: ileri
//                    {
//                        // Karakterin ileri yönü boyunca projeksiyon (dot) al
//                        float frontDist = Vector3.Dot(diff, shoulderReference.forward);
//                        if (frontDist > maxFrontDist)
//                        {
//                            maxFrontDist = frontDist;
//                            frontMaxDistanceRighthand = handPos;
//                        }
//                        break;
//                    }
//                case 2: // 2. adým: yukarý
//                    {
//                        float upDist = Vector3.Dot(diff, shoulderReference.up);
//                        if (upDist > maxUpDist)
//                        {
//                            maxUpDist = upDist;
//                            upMaxDistanceRighthand = handPos;
//                        }
//                        break;
//                    }
//                case 3: // 3. adým: saða
//                    {
//                        float rightDist = Vector3.Dot(diff, shoulderReference.right);
//                        if (rightDist > maxRightDist)
//                        {
//                            maxRightDist = rightDist;
//                            rightMaxDistanceRighthand = handPos;
//                        }
//                        break;
//                    }
//                case 4: // 4. adým: sola
//                    {
//                        // sola gitme mesafesi negatif dot vereceði için tersine çevir
//                        float leftDist = -Vector3.Dot(diff, shoulderReference.right);
//                        if (leftDist > maxLeftDist)
//                        {
//                            maxLeftDist = leftDist;
//                            leftMaxDistanceRighthand = handPos;
//                        }
//                        break;
//                    }
//            }
//        }

//        // A tuþu ile adýmlar arasý geçiþ ve bilgilendirme
//        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
//        {
//            if (isPressed && !previousPressedState && Time.time - _lastStepUpTime >= 0.5f)
//            {
//                _lastStepUpTime = Time.time;
//                _step++;

//                switch (_step)
//                {
//                    case 1:
//                        infoText.text = "Elini olabildigince ileri götür ve tekrar A’ya bas";
//                        break;
//                    case 2:
//                        infoText.text = "Elini olabildigince yukarý götür ve tekrar A’ya bas";
//                        break;
//                    case 3:
//                        infoText.text = "Elini olabildigince saða götür ve tekrar A’ya bas";
//                        break;
//                    case 4:
//                        infoText.text = "Elini olabildigince sola götür ve tekrar A’ya bas";
//                        break;
//                    case 5:
//                        // Ölçümler tamamlandý
//                        infoText.text = "Tebrikler! Ölçümler tamamlandý.";
//                        CalculateShoulderAndCollider();
//                        break;
//                }
//            }
//            previousPressedState = isPressed;
//        }
//    }

//    private void CalculateShoulderAndCollider()
//    {
//        // Omuz noktasý
//        Vector3 horizontalCenter = (rightMaxDistanceRighthand + leftMaxDistanceRighthand) / 2f;
//        Vector3 verticalCenter = (upMaxDistanceRighthand + frontMaxDistanceRighthand) / 2f;
//        Vector3 shoulderPos = (horizontalCenter + verticalCenter) / 2f;

//        // Sphere Collider oluþtur
//        GameObject colObj = new GameObject("ShoulderReachCollider");
//        colObj.transform.position = shoulderPos;
//        colObj.transform.parent = transform;
//        SphereCollider sphere = colObj.AddComponent<SphereCollider>();
//        sphere.isTrigger = true;

//        // Yarýçapý dört yöndeki maksimum uzaklýklarýn ortalamasý olarak al
//        float rFront = maxFrontDist;
//        float rUp = maxUpDist;
//        float rRight = maxRightDist;
//        float rLeft = maxLeftDist;
//        sphere.radius = (rFront + rUp + rRight + rLeft) / 4f;
//    }
//}

using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ConfigurationSC : MonoBehaviour
{
    [Header("Olcum Sonuclari (World Pozisyon)")]
    public Vector3 frontMaxDistanceRighthand;
    public Vector3 upMaxDistanceRighthand;
    public Vector3 rightMaxDistanceRighthand;
    public Vector3 leftMaxDistanceRighthand;

    [Header("UI")]
    public TextMeshPro infoText;

    // adim takibi
    private int _step = 0;
    private bool _prevPressed = false;
    private float _lastPressTime = 0f;

    // base pozisyon ve her yon icin max uzaklik
    private Vector3 _basePosition;
    private float _maxFrontDist, _maxUpDist, _maxRightDist, _maxLeftDist;

    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        bool hasPos = device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 handPos);
        bool hasBtn = device.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);

        // 1-4 arasindaki adimlar icin olcum
        if (hasPos && _step >= 1 && _step <= 4)
        {
            Vector3 diff = handPos - _basePosition;

            switch (_step)
            {
                case 1:
                    float front = Vector3.Dot(diff, transform.forward);
                    if (front > _maxFrontDist)
                    {
                        _maxFrontDist = front;
                        frontMaxDistanceRighthand = handPos;
                    }
                    break;

                case 2:
                    float up = Vector3.Dot(diff, transform.up);
                    if (up > _maxUpDist)
                    {
                        _maxUpDist = up;
                        upMaxDistanceRighthand = handPos;
                    }
                    break;

                case 3:
                    float right = Vector3.Dot(diff, transform.right);
                    if (right > _maxRightDist)
                    {
                        _maxRightDist = right;
                        rightMaxDistanceRighthand = handPos;
                    }
                    break;

                case 4:
                    float left = -Vector3.Dot(diff, transform.right);
                    if (left > _maxLeftDist)
                    {
                        _maxLeftDist = left;
                        leftMaxDistanceRighthand = handPos;
                    }
                    break;
            }
        }

        // A tusu ile adim ilerletme
        if (hasBtn && pressed && !_prevPressed && Time.time - _lastPressTime >= 2f)
        {
            _lastPressTime = Time.time;
            _step++;

            switch (_step)
            {
                case 1:
                    // ilk adim: base kaydet ve front olcumu icin hazirlan
                    _basePosition = hasPos ? handPos : Vector3.zero;
                    _maxFrontDist = 0f;
                    infoText.text = "Elini ileri gotur ve tekrar A'ya bas";
                    break;

                case 2:
                    _maxUpDist = 0f;
                    infoText.text = "Elini yukari gotur ve tekrar A'ya bas";
                    break;

                case 3:
                    _maxRightDist = 0f;
                    infoText.text = "Elini saga gotur ve tekrar A'ya bas";
                    break;

                case 4:
                    _maxLeftDist = 0f;
                    infoText.text = "Elini sola gotur ve tekrar A'ya bas";
                    break;

                case 5:
                    infoText.text = "Olcumler tamamlandi!";
                    Invoke("GoMainScene",1f);
                    CreateShoulderCollider();
                    break;
            }
        }

        _prevPressed = hasBtn && pressed;
    }

    public void GoMainScene()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }

    private void CreateShoulderCollider()
    {
        // omuz pozunu ekstremelerin ortasindan hesapla
        Vector3 horizCenter = (rightMaxDistanceRighthand + leftMaxDistanceRighthand) * 0.5f;
        Vector3 vertCenter = (upMaxDistanceRighthand + frontMaxDistanceRighthand) * 0.5f;
        Vector3 shoulderPos = (horizCenter + vertCenter) * 0.5f;
        DataBaseMuhammet.shoulderPos = shoulderPos;
        // collider objesi
        var go = new GameObject("ShoulderReachCollider");
        go.transform.parent = transform;
        go.transform.position = shoulderPos;

        var sph = go.AddComponent<SphereCollider>();
        sph.isTrigger = true;

        // yari cap ortalama uzaklik
        DataBaseMuhammet.colliderRadius = (_maxFrontDist + _maxUpDist + _maxRightDist + _maxLeftDist) * 0.25f;
        sph.radius = (_maxFrontDist + _maxUpDist + _maxRightDist + _maxLeftDist) * 0.25f;

    }
}
