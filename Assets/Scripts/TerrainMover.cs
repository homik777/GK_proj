using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Area
{
    public float min, max;
}

public class TerrainMover : MonoBehaviour {

    public Area area1;
    public Area area2;
    public Area area3;
    public float z = 60;
    public float y = -6;
    public float time =0;
    public GameObject[] trees;
    public Material groundMaterial;
    public float iteration;
    public float spawnWait;
    public int density;
    public float speed;
	// Use this for initialization
	void Start () {
        trees = Resources.LoadAll<GameObject>("Trees");
        StartCoroutine(Spawn(area1));
        StartCoroutine(Spawn(area2));
        StartCoroutine(Spawn(area3));
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > spawnWait*density)
        {
            StartCoroutine(Spawn(area1));
            StartCoroutine(Spawn(area2));
            StartCoroutine(Spawn(area3));
            time = 0;
        }
        
	}

    IEnumerator Spawn(Area area)
    {
        for (int i = 0; i < density; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(area.min,area.max), y, z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(trees[Random.Range(0, trees.Length)], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
        
    }

    void FixedUpdate()
    {
        Vector2 currentOffset = groundMaterial.GetTextureOffset("_MainTex");
        currentOffset.y += speed *Time.deltaTime;
        groundMaterial.SetTextureOffset("_MainTex", currentOffset);
    }
}
