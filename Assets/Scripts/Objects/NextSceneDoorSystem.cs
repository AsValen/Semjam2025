using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneDoorSystem : MonoBehaviour
{
    [SerializeField] private string scene;
    public NextSceneDoor door1; // Reference to the first door
    public NextSceneDoor door2; // Reference to the second door
    

    private void Update() {
        // Check if both pressure plates are activated
        if (door1.IsActivated && door2.IsActivated) {
            SceneManager.LoadScene(scene);
        }
    }
}
