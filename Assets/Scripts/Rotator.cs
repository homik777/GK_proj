using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public int speed; 
	
	void Update () {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
