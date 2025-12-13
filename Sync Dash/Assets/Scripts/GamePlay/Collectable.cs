using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int score = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager script = FindAnyObjectByType<ScoreManager>();
            script.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}
