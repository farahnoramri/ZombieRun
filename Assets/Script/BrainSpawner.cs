using UnityEngine;



public class BrainSpawner : MonoBehaviour

{

    [SerializeField]

    private GameObject brainPrefab;



    [SerializeField]

    private float minSpawnInterval = 3f;



    [SerializeField]

    private float maxSpawnInterval = 6f;



    private float spawnTimer = 0f;

    private float nextSpawnTime;



    private void Start()

    {

        nextSpawnTime = Random.Range(

            minSpawnInterval,

            maxSpawnInterval

        );

    }



    private void Update()

    {

        spawnTimer += Time.deltaTime;



        if (spawnTimer >= nextSpawnTime)

        {

            SpawnBrain();



            spawnTimer = 0f;



            nextSpawnTime = Random.Range(

                minSpawnInterval,

                maxSpawnInterval

            );

        }

    }



    private void SpawnBrain()

    {

        if (brainPrefab == null)

        {

            Debug.LogWarning("Brain Prefab not assigned!");

            return;

        }



        Instantiate(

            brainPrefab,

            transform.position,

            Quaternion.identity

        );

    }

} 