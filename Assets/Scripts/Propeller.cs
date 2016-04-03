using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.rotation = Quaternion.Euler(-90, rb.velocity.y + 10, rb.velocity.z + 10);
    }
}