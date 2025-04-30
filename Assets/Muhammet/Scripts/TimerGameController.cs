using UnityEngine;
using UnityEngine.UI;

public class TimerGameController : MonoBehaviour
{
    public Slider leftSlider;

    private void Start()
    {
        leftSlider.maxValue = DataBaseMuhammet.leftTimeTask;
        leftSlider.value = leftSlider.maxValue;
    }
    private void Update()
    {
        leftSlider.value -= Time.deltaTime;
        if (leftSlider.value<= 0.01f)
        {
            Debug.Log("Game Over");
        }
    }
}
