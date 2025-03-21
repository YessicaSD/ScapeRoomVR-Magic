using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    public float floatSpeed = 1f; // Speed of floating
    public float floatAmount = 0.5f; // How much it moves up and down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
