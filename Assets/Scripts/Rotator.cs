using UnityEngine;

public class Rotator : MonoBehaviour
{

    public int speed;
    public GameObject parentObject;
    public Vector3 relativePosition;
    void Update()
    {
        transform.position = parentObject.transform.position + relativePosition;
    }
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y + speed, 0);
    }
}