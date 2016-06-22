using UnityEngine;
using System.Collections;

public class AddLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.x > 0.05)
            transform.position += transform.right * -0.01f;
        if (transform.position.y > 0.1)
            transform.position += transform.up * -0.01f;
        if ((transform.position.x <= 0.05) && (transform.position.y <= 0.1))
        {
            GameObject.Find("Player").GetComponent<Movement>().addOneLife();
            GameObject.Find("Hearth").GetComponent<GUITexture>().enabled = false;
            this.enabled = false;
        }
    }
}
