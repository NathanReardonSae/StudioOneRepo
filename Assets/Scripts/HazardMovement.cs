using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float moveRangeX = 5f; // Range of movement along the X axis
    public float moveRangeY = 5f; // Range of movement along the Y axis
    public float changeDirectionInterval = 2f; // Time interval to change direction

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float elapsedTime = 0f;
    private float directionChangeTime;

    private void Start()
    {
        startPosition = transform.position;
        directionChangeTime = Time.time + changeDirectionInterval;
        SetNewTargetPosition();
    }

    private void Update()
    {
        // Move towards the target position
        elapsedTime += Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime);

        // Change direction periodically
        if (Time.time >= directionChangeTime)
        {
            SetNewTargetPosition();
            directionChangeTime = Time.time + changeDirectionInterval;
            elapsedTime = 0f;
        }
    }

    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(-moveRangeX, moveRangeX);
        float randomY = Random.Range(-moveRangeY, moveRangeY);
        targetPosition = startPosition + new Vector3(randomX, randomY, 0);
    }
}

