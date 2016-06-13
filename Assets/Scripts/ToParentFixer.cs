using UnityEngine;
using System.Collections;

public class ToParentFixer : MonoBehaviour {


    public Transform parent;
    public bool hasRotator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   
        transform.eulerAngles = parent.eulerAngles;
        transform.position = parent.position;
        
	}
}
