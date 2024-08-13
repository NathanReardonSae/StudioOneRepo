using UnityEngine;

public class SpikeRandomMovement : MonoBehaviour
{
    public float speed = 2.0f;      // Speed of the spike's movement
    public float changeDirectionInterval = 2.0f; // Time interval to change direction

    private Rigidbody2D rb;       // Reference to the Rigidbody2D component
    private float timeSinceLastChange;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        SetRandomDirection(); // Set an initial random direction
        timeSinceLastChange = 0f; // Initialize the time since last direction change
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        // Check if it's time to change direction
        if (timeSinceLastChange >= changeDirectionInterval)
        {
            SetRandomDirection();
            timeSinceLastChange = 0f; // Reset the timer
        }

        // Move the spike
        rb.velocity = movementDirection * speed;
    }

    // Method to set a new random direction
    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f); // Random angle
        movementDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }
}


