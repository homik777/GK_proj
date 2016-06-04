using UnityEngine;

public class Rotator : MonoBehaviour
{

    public int speed;
    public Transform parentObject;
    public Vector3 relativePosition;
    void Update()
    {
        transform.position = parentObject.position + relativePosition;
        transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y + speed, 0);
    }
}