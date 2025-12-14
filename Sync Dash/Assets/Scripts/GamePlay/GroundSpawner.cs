using UnityEngine;


public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner Instance;

    public Transform player;
    public Transform firstGround;

    [SerializeField] private float tileLength  = 50;
    [SerializeField] private int tilesAhead = 3;
    private Vector3 nextSpawnPoint;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Start at the END of the first ground
        nextSpawnPoint = firstGround.position + Vector3.forward * tileLength;

        //Spawn initial tiles
        for (int i = 0; i < tilesAhead; i++)
        {
            SpawnGround();
        }
    }

    private void Update()
    {
        //Spawn when player is close to end
        if (player.position.z + (tileLength + tilesAhead) > nextSpawnPoint.z)
        {
            SpawnGround();
        }
    }


    public void SpawnGround()
    {
        ObjectPooler.Instance.SpawnFromPool("Ground", nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint.z += tileLength;
    }
}
