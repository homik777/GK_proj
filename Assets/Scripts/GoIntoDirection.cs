using UnityEngine;
using System.Collections;

public class GoIntoDirection : MonoBehaviour {

    public GameObject boundary;
    public float speed;
	// Use this for initialization
	void Start () {
        boundary = GameObject.Find("Boundary");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.forward * speed *Time.deltaTime;
        if (Mathf.Abs(transform.position.z - boundary.transform.position.z) < 1)
        {
            SpawnController.enemyArray.Remove(gameObject);
            Destroy(this.gameObject);
        }
	}
}
