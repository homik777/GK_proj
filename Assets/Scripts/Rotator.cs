using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public int speed; 
	
	void FixedUpdate () {
        transform.eulerAngles += Vector3.forward * speed;
    }
}
