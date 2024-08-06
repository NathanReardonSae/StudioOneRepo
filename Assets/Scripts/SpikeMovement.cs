using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the spike movement
    public float distance = 2.0f; // Distance the spike will move up and down

    private Vector3 startPosition;
    private float timer;

    void Start()
    {
        startPosition = transform.position; // Store the initial position of the spike
    }

    void Update()
    {
        // Use Mathf.PingPong to move the spike up and down
        timer += Time.deltaTime * speed;
        float yOffset = Mathf.PingPong(timer, distance);
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}


