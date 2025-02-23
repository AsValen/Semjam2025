using UnityEngine;
using TMPro;

public class HackingPanel : MonoBehaviour
{
    public GameObject hackingUI; // Assign the hacking UI panel in the Inspector
    public GameObject door;
    public GameObject door2;// Assign the door GameObject to open after hacking
    public TMP_Text promptText; // Assign the TMP_Text UI element in the Inspector

    private bool playerInRange = false;
    private bool isHacking = false;
    private bool hackingCompleted = false; // Track if the hacking is completed

    void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false); // Hide prompt at start
        }
        hackingUI.SetActive(false); // Make sure UI is hidden at start
        door.SetActive(false); // Make sure the door is initially hidden
        door2.SetActive(false); // Make sure the door is initially hidden
    }

    void Update()
    {
        if (playerInRange && !hackingCompleted && !isHacking && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartHacking();
        }
    }

    void StartHacking()
    {
        isHacking = true;
        hackingUI.SetActive(true); // Show hacking UI
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false); // Hide prompt when hacking starts
        }
    }

    public void CompleteHacking()
    {
        isHacking = false;
        hackingCompleted = true; // Mark hacking as complete
        hackingUI.SetActive(false); // Hide hacking UI
        door.SetActive(true);
        door2.SetActive(true);// Open the door (or disable the door object to "open" it)
        Debug.Log("Hacking complete! Door opened.");
    }

    public void ResetHackingUI() // Reset UI for reuse
    {
        // Reset hacking state
        hackingCompleted = false;
        isHacking = false;

        // Hide the UI and show prompt again when player is in range
        hackingUI.SetActive(false); // Hide hacking UI
        door.SetActive(false); // Hide the door

        if (promptText != null)
        {
            promptText.gameObject.SetActive(true); // Show prompt to interact
        }

        Debug.Log("Hacking UI reset for next puzzle.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hackingCompleted)
        {
            playerInRange = true;
            if (promptText != null)
            {
                promptText.text = "Press ↑ to Hack";
                promptText.gameObject.SetActive(true); // Show prompt when player is in range
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false); // Hide prompt when player leaves range
            }
        }
    }
}