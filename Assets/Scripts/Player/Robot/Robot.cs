using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private const string GROUND = "Ground";

    [SerializeField] private float moveInput = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    //Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
        }
    }
}
