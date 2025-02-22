using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private const string GROUND = "Ground";

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update() {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement() {

        float moveInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveInput = -1f; // Move left
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            moveInput = 1f; // Move right
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump() {
    //Casts a ray downward and checks for collider
    RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f);

    isGrounded = hit.collider != null; //If the ray hits something on ground true

    if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}