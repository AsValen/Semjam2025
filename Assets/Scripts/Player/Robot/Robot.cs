using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update() {
        HandleMovement();
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


}
