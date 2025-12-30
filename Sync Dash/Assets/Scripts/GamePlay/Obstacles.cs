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

        // Shake first
        cameraShake?.Shake();

        // Delay death slightly
        Invoke(nameof(KillPlayer), 0.5f);
    }

    private void KillPlayer()
    {
        GameEvents.onPlayerDied?.Invoke();
        GetComponent<Collider>().enabled = false;
    }


}
