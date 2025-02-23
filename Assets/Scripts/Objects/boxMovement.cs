using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float force = 10f;
    private Rigidbody2D rb;

    [SerializeField] private float moveInput = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        HandleMovement();
        HandleVertical();
    }

    private void HandleMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f; // Move right
        }
        else
        {
            moveInput = 0f;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleVertical()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -force);
        }
        
    }

}
