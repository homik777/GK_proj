using UnityEngine;
using System.Collections;

public class ToCamera : MonoBehaviour
{
    Camera camera;
    // Use this for initialization
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camera != null)
        {
            transform.LookAt(camera.transform);
            transform.forward *= -1;
        }
    }
}