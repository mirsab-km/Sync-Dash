using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        if (cameraShake != null)
            cameraShake.Shake();
        other.gameObject.SetActive(false);
        GameEvents.onPlayerDied?.Invoke();
    }
}
