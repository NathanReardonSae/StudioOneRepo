using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float speed = 2.0f;   // Speed at which the block moves left and right
    public float distance = 5.0f; // Maximum distance the block will move from its starting position

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the block
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new X position based on a PingPong function
        float newX = Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = startPosition + new Vector3(newX, 0, 0);
    }
}

