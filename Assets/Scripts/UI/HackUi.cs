using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class HackUi : MonoBehaviour
{
    public TMP_Text progressText, introText;
    public List<Button> buttons; // Assign all 10 buttons in Inspector
    public HackingPanel hackingPanel; // 🔹 Reference to the HackingPanel script

    private List<int> numbers = new List<int>();
    private int currentNumber = 1; // Track the next correct number

    void Start()
    {
        progressText.text = "";
        AssignRandomNumbers();
        if (introText != null)
        {
            introText.text = "Click from 1 to 10";
        }
    }

    void AssignRandomNumbers()
    {
        if (buttons == null || buttons.Count == 0)
        {
            Debug.LogError("Buttons list is empty! Assign buttons in the Inspector.");
            return;
        }

        numbers.Clear();
        List<int> availableNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        if (buttons.Count != availableNumbers.Count)
        {
            Debug.LogError($"Mismatch: {buttons.Count} buttons, but {availableNumbers.Count} numbers available.");
            return;
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            int randomIndex = Random.Range(0, availableNumbers.Count);
            int chosenNumber = availableNumbers[randomIndex];
            availableNumbers.RemoveAt(randomIndex);

            TMP_Text buttonText = buttons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = chosenNumber.ToString();
            }
            else
            {
                Debug.LogError($"Button {buttons[i].name} is missing a TMP_Text component!");
            }

            // 🔥 Fixing Event Listener Issue
            int buttonNumber = chosenNumber;
            Button button = buttons[i]; // Store reference to avoid closure issue
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => CheckNumber(buttonNumber, button));
        }

        Debug.Log("Numbers assigned successfully.");
    }

    void CheckNumber(int number, Button clickedButton)
    {
        Debug.Log($"Button clicked: {number}, Expected: {currentNumber}");

        if (number == currentNumber) // ✅ Correct number clicked
        {
            clickedButton.image.color = Color.green;
            currentNumber++;
            progressText.text = "";

            if (currentNumber > 10) // 🎉 All numbers clicked correctly
            {
                progressText.text = "Task Complete";
                Debug.Log("Task Complete!");

                // ✅ Call CompleteHacking when finished
                if (hackingPanel != null)
                {
                    hackingPanel.CompleteHacking();
                }
                else
                {
                    Debug.LogError("HackingPanel reference is missing in HackUi!");
                }
            }
        }
        else // ❌ Wrong number clicked
        {
            if (clickedButton.image.color != Color.green)
            {
                progressText.text = "Wrong button";
                clickedButton.image.color = Color.red;
            }
        }
    }
}
