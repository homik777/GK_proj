using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

    private bool up = false;
    private float pos;
    public int rot;
    public float speed;
    private float add = 0.0f;
    private static GameObject player;
    private static GameObject boundary;
    private CapsuleCollider collider;
    private SphereCollider playerCollider;
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        if (player == null)
        {
            player = GameObject.Find("Player");
            boundary = GameObject.Find("Boundary");
        }

        if (player != null)
        {
            playerCollider = player.GetComponent<SphereCollider>();
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(rot,rot,rot));
        transform.position -= new Vector3(0, 0, speed);
    }
}
