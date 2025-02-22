using UnityEngine;

public class PressurePlate1 : MonoBehaviour
{
    private const string PLAYER = "Player";
    public bool IsActivated { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(PLAYER)) // Check if the object is a player
        {
            IsActivated = true;
            Debug.Log("Activated");
        }else{
            IsActivated = false;
            Debug.Log("Deactivate");
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