using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int score = 1;
    public int orbID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.CollectSound();
            ScoreManager script = FindAnyObjectByType<ScoreManager>();
            script.AddScore(score);
            StateSyncManager.Instance.NotifyOrbCollected(orbID);
            gameObject.SetActive(false);
        }
    }
}
