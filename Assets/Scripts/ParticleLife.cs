using UnityEngine;
using System.Collections;

public class ParticleLife : MonoBehaviour {

    // Use this for initialization
    public float lifeTime;
    public float speed;
    public Vector3 direction;
    public Color colorStart;
    private float timer;
	void Start () {
        Destroy(this.gameObject, lifeTime);
    }
	
	// Update is called once per frame
    void FixedUpdate () {
        Color c = GetComponent<Renderer>().material.GetColor("_TintColor");
        c.g += 0.05f;
        c.b -= 0.05f;
        GetComponent<Renderer>().material.SetColor("_TintColor", c);
        transform.localScale *= 0.9f;
        transform.position += direction * speed;
	}
}
