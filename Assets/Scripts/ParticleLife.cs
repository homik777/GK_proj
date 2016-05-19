using UnityEngine;
using System.Collections;

public class ParticleLife : MonoBehaviour {

    // Use this for initialization
    public float lifeTime;
    public float speed;
    public Vector3 direction;
    public Vector3 colorChange;
    public float scaling;
    public bool allDirections;
    private float timer;
	void Start () {
        if (allDirections)
        {
            direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
        Destroy(transform.parent.gameObject, lifeTime);
    }
	
	// Update is called once per frame
    void FixedUpdate () {
        Color c = GetComponent<Renderer>().material.GetColor("_TintColor");
        c.r += colorChange.x;
        c.g += colorChange.y;
        c.b += colorChange.z;
        GetComponent<Renderer>().material.SetColor("_TintColor", c);
        transform.localScale *= scaling;
        transform.position += direction * speed;
	}
}
