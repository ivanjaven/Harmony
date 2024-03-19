using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public SkinManager skinManager;
    public Transform spawnPoint;
    public float spawnInterval = 1f;
    public float spawnHeightOffset = 1f;
    public float spawnXOffsetRange = 1f; // Range for random x-axis offset
    public float spawnYGap = 80f; // Vertical gap between obstacles
    public float difficultyIncreaseInterval = 10f;
    public float spawnRateIncrease = 0.1f;

    private float nextSpawnTime;
    private float nextDifficultyIncreaseTime;
    private Vector3 lastSpawnPosition;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
        lastSpawnPosition = spawnPoint.position;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            skinManager.ChangeObstacleSprites();
            nextSpawnTime = Time.time + spawnInterval;
        }

        if (Time.time >= nextDifficultyIncreaseTime)
        {
            IncreaseDifficulty();
            nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        float randomXOffset = Random.Range(-spawnXOffsetRange, spawnXOffsetRange);
        Vector3 spawnPosition = lastSpawnPosition + new Vector3(randomXOffset, spawnYGap, 0);

        // Find or create the "Obstacles" game object
        GameObject obstacleContainer = GameObject.Find("Obstacles");
        if (obstacleContainer == null)
        {
            obstacleContainer = new GameObject("Obstacles");
        }

        // Instantiate the obstacle prefab
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Set the parent of the new obstacle to the "Obstacles" game object
        newObstacle.transform.parent = obstacleContainer.transform;

        lastSpawnPosition = spawnPosition;
    }

    private void IncreaseDifficulty()
    {
        spawnInterval *= (1 - spawnRateIncrease);
    }
}