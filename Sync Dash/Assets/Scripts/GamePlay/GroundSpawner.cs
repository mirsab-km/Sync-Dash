using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform firstGround; 
    private Vector3 nextSpawnPoint;

    void Start()
    {
        // Start at the END of the first ground
        nextSpawnPoint = new Vector3(
            firstGround.position.x,
            firstGround.position.y,
            firstGround.position.z + 50f  
        );

        // Spawn second tile onwards
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    void SpawnTile()
    {
        // Spawn at nextSpawnPoint
        Instantiate(groundPrefab, nextSpawnPoint, Quaternion.identity);

        // Update next spawn
        nextSpawnPoint.z += 50f; 
    }
}
