using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // Assign MainMenuCanvas in the Inspector

    public void StartGame()
    {
        mainMenuUI.SetActive(false); // Hide the main menu
        Time.timeScale = 1f; // Ensure game runs normally
    }

    void Start()
    {
        mainMenuUI.SetActive(true); // Show menu at the start
        Time.timeScale = 0f; // Pause the game until player starts
    }
}