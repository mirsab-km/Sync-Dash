using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;

    [Header("Shake Settings")]
    public float shakeDuration = 0.2f;
    public float shakeStrength = 0.15f;

    private float shakeTime;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeStrength;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            transform.localPosition = originalPosition;
        }
    }

    // Call this from other scripts
    public void Shake()
    {
        shakeTime = shakeDuration;
    }
}
