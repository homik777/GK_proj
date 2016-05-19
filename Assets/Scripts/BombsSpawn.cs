using UnityEngine;
using System.Collections;

public class BombsSpawn : MonoBehaviour {

    // Use this for initialization
    public float spawnRate;
    private float spawnTimer;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            Instantiate(spawner, spawner.transform.position, spawner.transform.rotation);
            spawnTimer = 0;
        }
    }
}
