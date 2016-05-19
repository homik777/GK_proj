using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {

    public GameObject particle;
    public Transform spawnPoint;
    public Vector3 spawnRadius;
    public float spawnRate;
    public float lifeTime;
    private Vector3 spawnPointReal;
    private float spawnTimer;
    void Start () {
        spawnRadius += spawnPoint.position;
        if (lifeTime != 0)
            Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnPointReal = new Vector3(Random.Range(spawnPoint.position.x, spawnRadius.x), Random.Range(spawnPoint.position.y, spawnRadius.y), Random.Range(spawnPoint.position.z, spawnRadius.z));
            Instantiate(particle, spawnPoint.position, particle.transform.rotation);
            spawnTimer = 0;
        }
	}
}
