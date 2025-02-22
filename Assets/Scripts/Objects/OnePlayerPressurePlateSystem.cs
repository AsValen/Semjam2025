using UnityEngine;

public class OnePlayerPressurePlateSystem : MonoBehaviour
{
    public GameObject door1; // Reference to the first door
    public GameObject door2; // Reference to the second door
    public PressurePlate plate1; // Reference to the first pressure plate
    public PressurePlate plate2; // Reference to the second pressure plate

    void Update() {
        // Check if both pressure plates are activated
        if (plate1.IsActivated)
        {
            OpenDoors1();
        } else {
            CloseDoors1();
        }

        if (plate2.IsActivated)
        {
            OpenDoors2();
        }
        else
        {
            CloseDoors2();
        }
    }

    void OpenDoors1() {
        door1.SetActive(false); // Deactivate the first door
    }
    void OpenDoors2()
    {
        door2.SetActive(false); // Deactivate the second door
    }

    void CloseDoors1() {
        //Close door 
    }
    void CloseDoors2()
    {
        //Close door 
    }
}