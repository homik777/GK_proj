using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {

    public float speed;
    public float lifeTime;
    private ScoreCounter scoreCounter;
    public GameObject boom;
	// Use this for initialization
	void Start () {
        scoreCounter = GameObject.Find("ScoreText").GetComponent<ScoreCounter>();
        Destroy(this.gameObject,lifeTime);
    }

    void Update()
    {

        GameObject obj;

        for (int i = 0; i <= SpawnController.enemyArray.Count - 1; i++)
        {

            obj = (GameObject)SpawnController.enemyArray[i];
            Collider collider = obj.GetComponent<CapsuleCollider>();
            
            if(collider != null)
            {
                CapsuleCollider item = (CapsuleCollider) collider;
                if ((Mathf.Abs(transform.position.x - item.transform.position.x)) < (item.height/2) && (Mathf.Abs(transform.position.z - item.transform.position.z) < (item.radius)))
                {
                    SpawnController.enemyArray.Remove(obj);
                    Instantiate(boom, transform.position,transform.rotation);
                    scoreCounter.addScore(obj.GetComponent<EnemyController>().score);
                    Destroy(obj);
                    Destroy(gameObject);
                }
            }else
            {
                SphereCollider item1 = obj.GetComponent<SphereCollider>();
                
            }

            
            
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed;
        
    }

   
	
}
