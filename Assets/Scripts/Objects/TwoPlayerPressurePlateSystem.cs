using UnityEngine;

public class TwoPlayerPressurePlateSystem : MonoBehaviour
{
    public GameObject door1; // Reference to the first door
    public GameObject door2; // Reference to the second door
    public PressurePlate plate1; // Reference to the first pressure plate
    public PressurePlate plate2; // Reference to the second pressure plate

    void Update() {
        // Check if both pressure plates are activated
        if (plate1.IsActivated && plate2.IsActivated)
        {
            OpenDoors();
        } else {
            CloseDoors();
        }
    }

    void OpenDoors() {
        door1.SetActive(false); // Deactivate the first door
        door2.SetActive(false); // Deactivate the second door
    }

    void CloseDoors() {
        //Close door 
    }
}