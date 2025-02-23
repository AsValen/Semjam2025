using UnityEngine;
using TMPro;

public class HackingPanel : MonoBehaviour
{
    public GameObject hackingUI; // Assign the hacking UI panel in the Inspector
    public GameObject door; // Assign the door GameObject to open after hacking
    public TMP_Text promptText; // Assign the TMP_Text UI element in the Inspector
    public GameObject unlockableObject;  

    private bool playerInRange = false;
    private bool isHacking = false;

    void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false); // Hide prompt at start
        }
        hackingUI.SetActive(false); // Make sure UI is hidden at start
    }

    void Update()
    {
        if (playerInRange && !isHacking && Input.GetKeyDown(KeyCode.UpArrow))
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
            promptText.gameObject.SetActive(false); // Hide prompt
        }
    }

    public void CompleteHacking()
    {
        isHacking = false;
        hackingUI.SetActive(false);
        door.SetActive(true);
        unlockableObject.SetActive(true);

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false); // ✅ Hide prompt
        }

        GetComponent<Collider2D>().enabled = false; // ✅ Prevent re-interaction
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptText != null)
            {
                promptText.text = "Press ↑ to Hack";
                promptText.gameObject.SetActive(true); // Show prompt
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
                promptText.gameObject.SetActive(false); // Hide prompt
            }
        }
    }
}
