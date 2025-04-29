using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        slider.value = 0;

        slider.maxValue = GameObject.FindGameObjectsWithTag("Apple").Length;

    }

    public void OnAppleAdd()
    {
        slider.value ++;
    }
    public void OnAppleExit()
    {
        slider.value--;
    }
}
