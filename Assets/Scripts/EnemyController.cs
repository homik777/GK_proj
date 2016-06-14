using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    
    public float speed;
    public int score;
    private ScoreCounter scoreCounter;
    private static GameObject player;
    private  static GameObject boundary;
    private CapsuleCollider collider;
    private SphereCollider playerCollider;
	// Use this for initialization
	void Start () {
        scoreCounter = GameObject.Find("ScoreText").GetComponent<ScoreCounter>();
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
	

    void Update()
    {
        if(player!=null)
        {
            float distance = Vector3.Distance(collider.transform.position, playerCollider.transform.position); ;
            if ((distance < (collider.radius + playerCollider.radius)))
            {
                /*Code for phisical contact here*/
                if (GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled)
                {
                    scoreCounter.addScore(score);
                } else
                    Destroy(player);
                SpawnController.enemyArray.Remove(gameObject);
                Destroy(this.gameObject);

            }
        }
        if (Mathf.Abs(transform.position.z- boundary.transform.position.z) <1)
        {
            SpawnController.enemyArray.Remove(gameObject);
            Destroy(this.gameObject);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        transform.position -= new Vector3(0, 0, speed);

	}
}
