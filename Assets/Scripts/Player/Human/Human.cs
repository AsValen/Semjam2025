using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    // Need to be change for isGounded if  double jump
    private bool isGrounded;
    private const string GROUND = "Ground";
    [SerializeField] private int jumpCharge = 2;
    [SerializeField] private int jumpChargeDefault = 2;

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

        if (Input.GetKey(KeyCode.A)) {
            moveInput = -1f; // Move left
        } 
        else if (Input.GetKey(KeyCode.D)) {
            moveInput = 1f; // Move right
        }

        rb.velocity= new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump() {

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            if(jumpCharge!=0)
            {
                jumpCharge--;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            } else
            {
                isGrounded = false; 
            }
        }
    }

    //Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            jumpCharge = jumpChargeDefault;
        }
    }
}
