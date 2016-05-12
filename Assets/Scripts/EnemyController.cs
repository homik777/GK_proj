using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position -= new Vector3(0, 0, speed);

	}
}
