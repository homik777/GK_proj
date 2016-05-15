using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {


    public static ArrayList enemyArray;

    public GameObject enemy;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public int maxEnemyCount;
    public int minEnemyCount;
    public float time;

    private int enemyCount;
    void Start()
    {
        enemyArray = new ArrayList();
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
     
            for (int i = 1; i <= enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                enemyArray.Add(Instantiate(enemy, spawnPosition, spawnRotation));
                yield return new WaitForSeconds(spawnWait);
            }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Jump") && SpawnController.enemyArray.Count<=2 )
        {
            if (time > spawnWait)
            {
                enemyCount = Random.Range(minEnemyCount, maxEnemyCount);
                StartCoroutine(SpawnWaves());
                time = 0;
            }
        }
    }
}
