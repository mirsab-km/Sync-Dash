using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI scoreText;

    [Header("Gameplay References")]
    public Transform player;

    private float distance;
    private int score;

    void Update()
    {
        UpdateDistance();
        UpdateUI();
    }

    void UpdateDistance()
    {
        distance = player.position.z;
    }

    void UpdateUI()
    {
        distanceText.text = Mathf.FloorToInt(distance).ToString();
        scoreText.text = "SCORE : " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
