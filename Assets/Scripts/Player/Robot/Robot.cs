using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    private Rigidbody2D rb;

    [SerializeField] private float moveInput = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update() {
        HandleMovement();
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
}

