using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class Movement : MonoBehaviour {

    public float speed;
    public float defaultHigh;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public GameObject rocket;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
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
        rb.rotation = Quaternion.Euler(rb.velocity.x * tilt, 90, rb.velocity.z * tilt);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shot.transform.rotation);
        }
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(rocket, shotSpawn.position, shot.transform.rotation);
        }
        
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
