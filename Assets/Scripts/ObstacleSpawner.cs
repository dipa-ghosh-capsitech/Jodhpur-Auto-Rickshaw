// using System.Collections;
// using UnityEngine;

// public class ObstacleSpawner : MonoBehaviour
// {
//     public GameObject[] obstacleSets;

//     public float minSpawnInterval = 2f; 
//     public float maxSpawnInterval = 3f;
//     public float spawnerInterval = 2.5f;
//     public float spawnRangeY = 2.5f;
//     public float moveSpeed = 3f;

//     private bool spawningActive = true;


//     void Start()
//     {
//         StartCoroutine(SpawnRoutine());
//     }

//     IEnumerator SpawnRoutine()
//     {

//         while (spawningActive)
//         {
//             yield return new WaitForSeconds(2f);

//             SpawnObstacleSet();
//             // float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
//             // yield return new WaitForSeconds(waitTime);
//         }
//     }
//     void SpawnObstacleSet()
//     {
//         if (obstacleSets.Length == 0) return;

//         int index = Random.Range(0, obstacleSets.Length);

//         GameObject prefab = obstacleSets[index];

//         float randomY = Random.Range(-spawnRangeY, spawnRangeY);

//         GameObject obstacle = Instantiate(prefab, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);

//         ObstacleMover mover = obstacle.AddComponent<ObstacleMover>();
//         mover.speed = moveSpeed;
//     }

//     public void StopSpawning()
//     {
//         spawningActive = false;
//         StopAllCoroutines();
//     }
// }



using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] obstacleSets;      
    [Header("Spawn Settings")]
    public float spawnRangeYmin ;    
     public float spawnRangeYmax ;   



    void Start()
    {
        InvokeRepeating("SpawnObstacleSet", 2,2);
    }

    void SpawnObstacleSet()
    {
       
        int idx = Random.Range(0, obstacleSets.Length);
        float randomY = Random.Range(spawnRangeYmin, spawnRangeYmax);
        
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);
        GameObject obstacle = Instantiate(obstacleSets[idx], spawnPos, Quaternion.identity);
        obstacle.transform.SetParent(transform);
        // Destroy(obstacle, 10f);


    }

   
}
