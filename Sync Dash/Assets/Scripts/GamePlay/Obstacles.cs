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

        // Camera shake (once)
        if (cameraShake != null)
            cameraShake.Shake();

        // STOP player movement
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            //rb.isKinematic = true; // fully stops physics
        }

        // Disable obstacle collider to avoid repeat hits
        GetComponent<Collider>().enabled = false;

        // Notify Game Over
        GameEvents.onPlayerDied?.Invoke();
    }
}
