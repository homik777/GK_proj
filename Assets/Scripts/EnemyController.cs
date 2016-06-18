using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    
    public float speed;
    public int score;
    public GameObject boom;
    private ScoreCounter scoreCounter;
    private static GameObject player;
    private  static GameObject boundary;
    private CapsuleCollider collider;
    public GameObject gameController;
    public GameObject scoreParticle;
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
                    GameObject scoreObj = (GameObject)Instantiate(scoreParticle, transform.position, transform.rotation);
                    scoreObj.GetComponentInChildren<TextMesh>().text = "" + score;
                } else
                {
                    player.GetComponent<Movement>().loseOneLife();
                    if(player.GetComponent<Movement>().lifes <= 0 )
                    {
                        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
                        Instantiate(boom, player.gameObject.transform.position, player.gameObject.transform.rotation);
                        Destroy(player.gameObject);
                    }
                    scoreCounter.updateLives(player.GetComponent<Movement>().lifes);
                }
                SpawnController.enemyArray.Remove(gameObject);
                Instantiate(boom, transform.position, transform.rotation);
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
