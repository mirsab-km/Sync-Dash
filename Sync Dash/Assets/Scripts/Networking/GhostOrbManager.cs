using UnityEngine;

public class GhostOrbManager : MonoBehaviour
{
    public static GhostOrbManager Instance;

    public GameObject[] ghostOrbs;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectOrb(int id)
    {
        if (id >= 0 && id < ghostOrbs.Length)
        {
            ghostOrbs[id].SetActive(false);
        }
    }
}
