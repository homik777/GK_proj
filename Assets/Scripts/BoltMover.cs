using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {

    public float speed;
    public float lifeTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject,lifeTime);
	}

    void Update()
    {
        GameObject obj;

        for (int i = 0; i <= SpawnController.enemyArray.Count - 1;i++ )
        {
            
            obj = (GameObject)SpawnController.enemyArray[0];
            CapsuleCollider[] colliders;
            colliders = obj.GetComponents<CapsuleCollider>();
            foreach (CapsuleCollider item in colliders)
            {
                if ((Mathf.Abs(transform.position.x - item.transform.position.x)) < (item.height / 0.1 * 2) && (Mathf.Abs(transform.position.z - item.transform.position.z) < (item.radius*0.1 )))
                {
                    SpawnController.enemyArray.RemoveAt(i);
                    Destroy(obj);
                    Destroy(gameObject);
                }
            }
        }
        
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed;
        
    }

   
	
}
