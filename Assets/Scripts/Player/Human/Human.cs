using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [SerializeField] private int jumpCharge = 2;
    [SerializeField] private int jumpChargeDefault = 2;

    private BoxCollider2D bc2d;
    [SerializeField] private float bigSize = 1.5f;
    [SerializeField] private float defaultSize = 1.0f;
    [SerializeField] private float smallSize = 0.5f;
    private int stateSize = 1;

    [SerializeField] private Sprite bigSprite;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite smallSprite;
    [SerializeField] private SpriteRenderer sr;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        HandleMovement();
        HandleJump();
        HandleSizeChange();
    }

    private void HandleMovement() {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A)) {
            moveInput = -1f; // Move left
        } 
        else if (Input.GetKey(KeyCode.D)) {
            moveInput = 1f; // Move right
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump() {
        if (Input.GetKeyDown(KeyCode.W)) {
            if (isGrounded) {
                jumpCharge = jumpChargeDefault; // Reset jump charge when grounded
            }

            if (jumpCharge > 0) {
                jumpCharge--;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false; // Player is no longer grounded after jumping
            }
        }
    }

    private void HandleSizeChange() {
        Vector2 newSize = bc2d.size;

        if (Input.GetKeyDown(KeyCode.Q) && stateSize < 2) {
            if (stateSize == 0) {
                sr.sprite = defaultSprite;
                newSize.y = defaultSize;
            } else {
                sr.sprite = bigSprite;
                newSize.y = bigSize;
            }

            stateSize += 1;

        } else if (Input.GetKeyDown(KeyCode.E) && stateSize > 0) {
            if (stateSize == 2) {
                sr.sprite = defaultSprite;
                newSize.y = defaultSize;
            } else {
                sr.sprite = smallSprite;
                newSize.y = smallSize;
            }

            stateSize -= 1;
        }

        bc2d.size = newSize;
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