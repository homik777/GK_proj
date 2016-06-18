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
    public float time =0;
    private bool gameStarted =false;
    public bool isEnemy;

    private int enemyCount;
    void Start()
    {
        enemyArray = new ArrayList();
        
    }

    IEnumerator SpawnWaves()
    {
            for (int i = 1; i <= enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                if (isEnemy)
                    enemyArray.Add(Instantiate(enemy, spawnPosition, spawnRotation));
                else
                    Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (SpawnController.enemyArray.Count<=1 && isEnemy)
        {
            if (time > startWait)
            {
                enemyCount = Random.Range(minEnemyCount, maxEnemyCount);
                StartCoroutine(SpawnWaves());
                time = 0;
            }
        }
        else if(!isEnemy)
        {
            if(time>startWait)
            {
                enemyCount = Random.Range(minEnemyCount, maxEnemyCount);
                StartCoroutine(SpawnWaves());
                time = 0;
            }
        }
    }
}
