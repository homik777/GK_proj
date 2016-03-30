using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public const float maxSpeed=2;
    public float defaultHigh = 1.72f;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        speed = 5;
	    rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(rightLeft(), 0.0f, upDown());


        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            defaultHigh,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt  +90);
    }

    

    float rightLeft()
    {
        return Input.GetAxis("Horizontal");
    }

    float upDown()
    {
        return Input.GetAxis("Vertical");
    }

    

}
