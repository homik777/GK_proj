using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

    public int rot;
    public float speed;
    private static GameObject player;
    private static GameObject boundary;
    private SphereCollider collider;
    private SphereCollider playerCollider;
    private float bonus;
    void Start()
    {
        bonus = Random.Range(0.0f, 1.0f);
        collider = GetComponent<SphereCollider>();
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
    void Update()
    {
        if (Mathf.Abs(transform.position.z - boundary.transform.position.z) < 1)
        {
            SpawnController.enemyArray.Remove(gameObject);
            Destroy(this.gameObject);
        }
        if (player != null)
        {
            float distance = Vector3.Distance(collider.transform.position, playerCollider.transform.position); ;
            if ((distance < (collider.radius + playerCollider.radius)))
            {
                if (bonus < 0.5f)
                    GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = true;
                else {
                    GameObject.Find("Hearth").transform.position = Camera.main.WorldToViewportPoint(transform.position);
                    GameObject.Find("Hearth").GetComponent<GUITexture>().enabled = true;
                    GameObject.Find("Hearth").GetComponent<AddLife>().enabled = true;
                }
                SpawnController.enemyArray.Remove(gameObject);
                Destroy(this.gameObject);
            }
        } 
    }
}
