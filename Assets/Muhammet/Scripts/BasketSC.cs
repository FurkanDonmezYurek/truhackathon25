using UnityEngine;

public class BasketSC : MonoBehaviour
{
    public int appleCount = 0;

    public UIController uiController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            uiController.OnAppleAdd();
            appleCount ++;
            Debug.Log("AppleCPunt = " + appleCount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            uiController.OnAppleExit();
            appleCount --;
            Debug.Log("AppleCPunt = " + appleCount);

        }
    }
}
