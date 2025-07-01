using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] lanePositions;
    public GameObject[] obstaclePrefabs;

    public float spawnInterval = 1.5f;
    public float spawnZ = 50f;
    public int maxObstacles = 10;

    private float timer;
    private int spawnedCount = 0;
    public Transform spawnPoint;

    void Update()
    {
        if (spawnedCount >= maxObstacles)
            return; 

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int laneIndex = Random.Range(0, lanePositions.Length);
        Vector3 basePos = lanePositions[laneIndex].position;
        Vector3 spawnPos = new Vector3(basePos.x, basePos.y + 1.0f, spawnZ);

        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned!");
            return;
        }

        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[index];
        Instantiate(obstacle, spawnPos, Quaternion.identity);

        spawnedCount++;
    }
}
