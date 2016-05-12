using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {


    public static ArrayList enemyArray;

    public GameObject enemy;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public int maxEnemyCount;

    private int enemyCount;
    void Start()
    {
        enemyCount = Random.Range(5, maxEnemyCount);
        enemyArray = new ArrayList();
        StartCoroutine(SpawnWaves());
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
}
