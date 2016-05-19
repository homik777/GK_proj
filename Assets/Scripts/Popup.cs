using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

    private bool up = false;
    private float pos;
    public int rot;
    private float add = 0.0f;
    void Start()
    {
        pos = transform.position.y;
    }
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(rot,rot,rot));
        //transform.position += transform.right * 0.1f;
	}
}
