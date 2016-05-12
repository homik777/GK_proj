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
    public Transform rocketSpawn_1;
    public Transform rocketSpawn_2;
    public float fireRate;
    
    public SphereCollider sc;
    float shotTimer;
    float rocketTimer;

    private bool switchSide;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody>();
	}
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        Vector3 movement = new Vector3(rightLeft(), 0.0f, upDown());

        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            defaultHigh,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        transform.eulerAngles = new Vector3(rb.velocity.x * tilt, 90, rb.velocity.z * tilt);
    }

    void Update()
    {
        shotTimer += Time.deltaTime;
        rocketTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && shotTimer >= fireRate)
        {
            Instantiate(shot, shotSpawn.position, shot.transform.rotation);
            shotTimer = 0;
        }
        if (Input.GetButton("Fire2") && rocketTimer >= fireRate)
        {
            if(switchSide)
            {
                Instantiate(rocket, rocketSpawn_1.position, shot.transform.rotation);
                switchSide = !switchSide;
            }
            else
            {
                Instantiate(rocket, rocketSpawn_2.position, shot.transform.rotation);
                switchSide = !switchSide;
            }
            
            rocketTimer = 0;
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
