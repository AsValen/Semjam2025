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

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if(p2SR == null)
        {
            p2SR = GetComponent<SpriteRenderer>();
        }

    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveInput = -1f; // Move left
            p2SR.sprite = playerLeft; // Move left animation
            Debug.Log(moveInput);
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            moveInput = 1f; // Move right
            p2SR.sprite = playerRight; // Move right animation
            Debug.Log(moveInput);
        } else
        {
            moveInput = 0f;
            p2SR.sprite = defaultSprite;
            Debug.Log(moveInput);
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        Debug.Log(rb.velocity);
    }
}