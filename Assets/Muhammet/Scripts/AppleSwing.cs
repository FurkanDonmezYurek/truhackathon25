using UnityEngine;

public class AppleSwing : MonoBehaviour
{
    // Salinma genligi (derece cinsinden)
    public float amplitude = 10f;
    // Salinma hizi (ne kadar hizli gidip gelecek)
    public float frequency = 5f;

    private Quaternion startRotation;

    public bool isSwing;
    public bool isSwinged;

    void Start()
    {
        // Baslangic rotasyonunu kaydet
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (!isSwinged)
        {
            if (isSwing)
            {
                // zamanla sinüs degeri hesapla
                float angle = amplitude * Mathf.Sin(Time.time * frequency);
                // objeyi Z ekseni etrafinda saga-sola cevir
                transform.localRotation = startRotation * Quaternion.Euler(0f, 0f, angle);
            }
        }



    }
}
