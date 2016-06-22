using UnityEngine;
using System.Collections;

public class Pulsing : MonoBehaviour {

    public Renderer renderer;
    int iterator = 0;
    float deltaTime = 0.2f;
    float deltaTimer = 0.0f;
	// Update is called once per frame
	void Update () {
        deltaTimer += Time.deltaTime;
        if (iterator < 6)
        {
            if (deltaTimer >= deltaTime)
            {
                renderer.enabled = !renderer.enabled;
                deltaTimer = 0;
                iterator++;
            }
        }
        else
        {
            renderer.enabled = true;
            iterator = 0;
            this.enabled = false;
        }
    }
}
