using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextSceneDoor : MonoBehaviour
{
    private const string PLAYER = "Player";
    public bool IsActivated { get; private set; } = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(PLAYER)) // Check if the object is a player
        {
            IsActivated = true;
            Debug.Log("Activated");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(PLAYER)) // Check if the object is a player
        {
            IsActivated = false;
            Debug.Log("Deactive");
        }
    }
}
