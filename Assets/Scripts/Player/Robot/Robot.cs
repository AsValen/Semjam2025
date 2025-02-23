using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float moveInput = 0f;
    private Rigidbody2D rb;
    public SpriteRenderer p2SR;
    public Sprite playerLeft;
    public Sprite playerRight;
    public Sprite defaultSprite;

    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    private BoxCollider2D bc2d;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        bc2d = GetComponent<BoxCollider2D>();

        if (p2SR == null)
        {
            p2SR = GetComponent<SpriteRenderer>();
        }

    }

    private void Update() {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveInput = -1f; // Move left
            p2SR.sprite = playerLeft; // Move left animation

        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            moveInput = 1f; // Move right
            p2SR.sprite = playerRight; // Move right animation
          
        } else
        {
            moveInput = 0f;
            p2SR.sprite = defaultSprite;
           
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    }

    private void HandleJump()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGroundCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckGroundCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the player leaves the object, check if they are still touching anything
        isGrounded = false;
    }

    private void CheckGroundCollision(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.point.y < transform.position.y - (bc2d.size.y / 2))
            {
                // Contact point is below the player's center - standing on something
                isGrounded = true;
                return; // No need to check further
            }
        }
    }
}