using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalLocalPos;

    [Header("Shake Settings")]
    public float shakeDuration = 0.2f;
    public float shakeStrength = 0.15f;

    private float timer;
    private void OnEnable()
    {
        GameEvents.onPlayerDied += StopShake;
    }

    private void OnDisable()
    {
        GameEvents.onPlayerDied -= StopShake;
    }

    private void Awake()
    {
        // Store original local position 
        originalLocalPos = transform.localPosition;
    }

    private void Update()
    {
        if (timer > 0)
        {
            // Random offset around original position
            Vector3 shakeOffset = Random.insideUnitSphere * shakeStrength;
            transform.localPosition = originalLocalPos + shakeOffset;

            timer -= Time.deltaTime;
        }
        else
        {
            // Reset position after shake
            timer = 0f;
            transform.localPosition = originalLocalPos;
        }
    }

    public void Shake()
    {
        timer = shakeDuration;
    }

    public void StopShake()
    {
        timer = 0f;
        transform.localPosition = originalLocalPos;
    }

}
