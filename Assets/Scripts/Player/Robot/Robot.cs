using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private const string GROUND = "Ground";

    private bool magnetGrabState = false;
    [SerializeField] private GameObject leftObjectRay;
    [SerializeField] private GameObject rightObjectRay;
    [SerializeField] private float obstacleRayDistance;

    [SerializeField] private float moveInput = 0f;
    private float characterDirection = 0f;
    private Vector2 rayOrigin = Vector2.zero;
    private int layerMask;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        layerMask = ~LayerMask.GetMask("Player");
    }

    private void Update() {
        HandleMovement();
        HandleJump();
        magnetGrab();
    }

    private void HandleMovement() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveInput = -1f; // Move left
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            moveInput = 1f; // Move right
        } else
        {
            moveInput = 0f;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump() {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; 
        }
    }

    //Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
        }
    }

    private void magnetGrab()
    {

        if (moveInput < 0)
        {
            characterDirection = -1f; 
            rayOrigin = leftObjectRay.transform.position;
        }
        else if (moveInput > 0) 
        {
            characterDirection = 1f;
            rayOrigin = rightObjectRay.transform.position;
        }

        // Calculate direction properly
        Vector2 direction = new Vector2(characterDirection, 0f);

        // Perform the Raycast
        RaycastHit2D hitObstacle = Physics2D.Raycast(rayOrigin, direction, obstacleRayDistance, layerMask);

        // Draw the ray in Scene view for debugging
        if (hitObstacle.collider != null)
        {
            Debug.Log("Enemy Detected! Attack Mode");
            Debug.DrawRay(rayOrigin, direction * obstacleRayDistance, Color.red);
        }
        else
        {
            Debug.Log("No Enemy");
            Debug.DrawRay(rayOrigin, direction * obstacleRayDistance, Color.green);
        }

        //if (Input.GetKeyDown(KeyCode.Ctrl))
        //{
        //    if(magnetGrabState)
        //    {
        //        magnetGrabState = false;
        //    } 
        //    else
        //    {
        //        magnetGrabState = true;
        //    }
        //}
    }
}
