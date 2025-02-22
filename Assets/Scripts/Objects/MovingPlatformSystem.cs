using UnityEngine;

public class MovingPlatformSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform endPoint;  
    [SerializeField] private Platform platform;

    private Vector3 startPoint; // Store initial position

    private void Start()
    {
        startPoint = platform.transform.position; // Set startPoint to platform's starting position
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        Vector3 targetPoint = platform.isPlayerOnPlatform ? endPoint.position : startPoint; // Move up if player is on it, down if not
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
}
