using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isPlayerOnPlatform { get; private set; } = false;

    // Detect when the player is on top
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player is on top by checking the collision normal
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < -0.5f)  // Normal points downward, meaning player is on top
                {
                    isPlayerOnPlatform = true;
                    collision.transform.SetParent(transform); // Parent the player to the platform
                    Debug.Log("Player is on the platform and parented.");
                    return; // Exit after detecting a valid contact
                }
            }
        }
    }

    // Detect when the player leaves the platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            collision.transform.SetParent(null); // Unparent the player
            Debug.Log("Player left the platform and unparented.");
        }
    }
}