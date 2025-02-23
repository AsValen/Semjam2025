using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGrab : MonoBehaviour
{

    private bool magnetGrabState = false;
    [SerializeField] private GameObject leftObjectRay;
    [SerializeField] private GameObject rightObjectRay;
    [SerializeField] private float obstacleRayDistance;

    [SerializeField] private float moveInput = 0f;
    private float characterDirection = 0f;
    private Vector2 rayOrigin = Vector2.zero;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        magnetGrab();
    }

    // Prevent box from knocking the robot down
    private void magnetGrab()
    {
        if (!magnetGrabState)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                characterDirection = -1f;
                rayOrigin = leftObjectRay.transform.position;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                characterDirection = 1f;
                rayOrigin = rightObjectRay.transform.position;
            }

        }

        // Calculate direction properly
        Vector2 direction = new Vector2(characterDirection, 0f);

        // Perform the Raycast
        RaycastHit2D hitObstacle = Physics2D.Raycast(rayOrigin, direction, obstacleRayDistance, layerMask);

        // Draw the ray in Scene view for debugging
        if (hitObstacle.collider != null && hitObstacle.collider.CompareTag("moveableObject"))
        {
            //Debug.Log("Enemy Detected! Attack Mode");
            Debug.DrawRay(rayOrigin, direction * obstacleRayDistance, Color.red);

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                var robotScript = GetComponent<Robot>();
                //var robotCollider = GetComponent<BoxCollider2D>();
                var boxScript = hitObstacle.collider.GetComponent<boxMovement>();

                if (magnetGrabState)
                {
                    robotScript.enabled = true;
                    //robotCollider.enabled = true;
                    boxScript.enabled = false;
                    magnetGrabState = false;
                }
                else
                {
                    robotScript.enabled = false;
                    //robotCollider.enabled = false;
                    boxScript.enabled = true;
                    magnetGrabState = true;
                }
            }
        }
        else
        {
            //Debug.Log("No Enemy");
            Debug.DrawRay(rayOrigin, direction * obstacleRayDistance, Color.green);
        }
    }
}
