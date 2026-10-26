using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _barrierObject;

    [Header("Spawning Details")]
    [SerializeField]
    private float _maxSpawnInterval = 2f;
    [SerializeField]
    private float _minSpawnInterval = 4f;
    private float spawnTimer;
    private float nextSpawnTime;
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= nextSpawnTime)
        {
            SpawnBarrier();
            spawnTimer = 0f;
            nextSpawnTime = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }

    private void SpawnBarrier()
    {
        if(_barrierObject==null || _barrierObject.Length == 0)
        {
            Debug.LogWarning("No barrier objects assigned in the array!");
            return;
        }
            int randomIndex = Random.Range(0, _barrierObject.Length);
            GameObject chosenObstacle = _barrierObject[randomIndex];

        if (chosenObstacle != null)
        {
            Instantiate(chosenObstacle, transform.position, Quaternion.identity);
        }
    }

}
