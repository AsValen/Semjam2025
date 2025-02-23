using UnityEngine;

public class CubePressurePlate : MonoBehaviour
{
    private const string CUBE = "moveableObject";
    public bool IsActivated { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(CUBE)) // Check if the object is a player
        {
            IsActivated = true;
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            Debug.Log("Activated");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(CUBE)) // Check if the object is a player
        {
            IsActivated = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Deactive");
        }
    }
}