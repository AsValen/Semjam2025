using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private const string GROUND = "Ground";

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

    public bool HUG = false;

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

        rb.velocity= new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump() {

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            if(jumpCharge!=0)
            {
                if (stateSize == 2) jumpCharge = 1;

                jumpCharge--;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);


            } else
            {
                isGrounded = false; 
            }
        }
    }

    private void HandleSizeChange()
    {
        Vector2 newSize = bc2d.size;

        if (Input.GetKeyDown(KeyCode.Q) && stateSize < 2)
        {
            if (stateSize == 0)
            {
                sr.sprite = defaultSprite;
                newSize.y = defaultSize;
            } else
            {
                sr.sprite = bigSprite;
                newSize.y = bigSize;
            }

            stateSize += 1;

        } else if (Input.GetKeyDown(KeyCode.E) && stateSize > 0)
        {
            if (stateSize == 2)
            {
                sr.sprite = defaultSprite;
                newSize.y = defaultSize;
            }
            else
            {
                sr.sprite = smallSprite;
                newSize.y = smallSize;
            }

            stateSize -= 1;
        }

        bc2d.size = newSize;
    }

    //Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            jumpCharge = jumpChargeDefault;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HUG = true;
            canvas.gameObject.SetActive(true);
            Debug.Log("HUGGING");
            
        }


    }
}
