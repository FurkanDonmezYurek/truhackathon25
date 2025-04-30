using UnityEngine;

public class BasketSC : MonoBehaviour
{
    public int appleCount = DataBaseMuhammet.appleCount;

    public UIController uiController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            uiController.OnAppleAdd();
            appleCount ++;
            Debug.Log("AppleCPunt = " + appleCount);

            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        if (other.CompareTag("BadApple"))
        {
            uiController.OnAppleExit();
            appleCount--;
            Debug.Log("AppleCPunt = " + appleCount);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            uiController.OnAppleExit();
            appleCount --;
            Debug.Log("AppleCPunt = " + appleCount);

            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

        }
        if (other.CompareTag("BadApple"))
        {
            uiController.OnAppleAdd();
            appleCount--;
            Debug.Log("AppleCPunt = " + appleCount);

        }
    }
}
