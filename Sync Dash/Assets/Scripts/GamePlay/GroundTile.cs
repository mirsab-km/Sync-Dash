using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float despawnDistance = 60f;

    private GameObject[] children;

    private void OnEnable()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        ResetTile();
    }

    private void Awake()
    {
        GetChild();
    }

    private void Update()
    {
        if (player.position.z - transform.position.z > despawnDistance)
        {
            gameObject.SetActive(false);
        }
    }

    void GetChild()
    {
        children = new GameObject[transform.childCount];

        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
    }

    public void ResetTile()
    {
        foreach (GameObject obj in children)
        {
            obj.SetActive(true);
        }
    }
}
