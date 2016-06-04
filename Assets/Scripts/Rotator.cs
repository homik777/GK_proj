using UnityEngine;

public class Rotator : MonoBehaviour
{

    public int speed;
    public Transform parent;
    public Vector3 relativePosition;
    private Quaternion relativeRotation;
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = parent.position + relativePosition;
        transform.rotation = parent.transform.rotation;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed * timer, transform.eulerAngles.z);
        if (timer >= 360)
        {
            timer = 0f;
        }
    }
}