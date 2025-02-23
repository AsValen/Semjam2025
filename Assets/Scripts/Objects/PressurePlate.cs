using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private const string PLAYER = "Player";
    public bool IsActivated { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(PLAYER)) // Check if the object is a player
        {
            IsActivated = true;
            Debug.Log("Activated");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(PLAYER)) // Check if the object is a player
        {
            IsActivated = false;
            Debug.Log("Deactive");
        }
    }
}