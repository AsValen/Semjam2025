using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HackUi : MonoBehaviour
{
    private int currentNumber = 1; // Starts at 1
    public TMP_Text progressText; // UI Text to show progress
    public GameObject taskCompletePanel; // Panel to show when finished

    void Start()
    {
        progressText.text = "Press the numbers from 1 to 10!";
        taskCompletePanel.SetActive(false); // Hide completion message
    }

    // This function is assigned to each button in the inspector
    public void OnNumberClick(int number)
    {
        if (number == currentNumber)
        {
            currentNumber++;

            if (currentNumber > 10) // If they clicked 1-10 in order
            {
                progressText.text = "Task Complete!";
                taskCompletePanel.SetActive(true); // Show success panel
            }
            else
            {
                progressText.text = "Next: " + currentNumber;
            }
        }
        else
        {
            progressText.text = "Wrong! Click " + currentNumber + " next.";
        }
    }
}