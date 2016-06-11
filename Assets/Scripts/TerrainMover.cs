using UnityEngine;
using System.Collections;

public class TerrainMover : MonoBehaviour {


    public Material groundMaterial;
    public float speed;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void FixedUpdate()
    {
        Vector2 currentOffset = groundMaterial.GetTextureOffset("_MainTex");
        currentOffset.y += speed *Time.deltaTime;
        groundMaterial.SetTextureOffset("_MainTex", currentOffset);
    }
}
