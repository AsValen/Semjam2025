using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private BoxCollider2D bc2d;

    [SerializeField] private float moveInput = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        HandleMovement();
        HandleJump();
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

    private void OnCollisionEnter2D(Collision2D collision) {
        CheckGroundCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        CheckGroundCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        // If the player leaves the object, check if they are still touching anything
        isGrounded = false;
    }

    private void CheckGroundCollision(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts) {
            if (contact.point.y < transform.position.y - (bc2d.size.y / 2)) { 
                // Contact point is below the player's center - standing on something
                isGrounded = true;
                return; // No need to check further
            }
        }
    }
}