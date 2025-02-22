using UnityEngine;

public class Aghh : MonoBehaviour
{
    [SerializeField] private GameObject door1; // Reference to the first door
    [SerializeField] private GameObject door2; // Reference to the second door
    [SerializeField] private GameObject door3; // Reference to the third door
    [SerializeField] private PressurePlate1 plate1; // Reference to the first pressure plate

    void Start(){
        // Make sure doors are inactive at the beginning
        door1.SetActive(true);
        door2.SetActive(false);
        door3.SetActive(true);
    }
    void Update(){
        // Check if pressure plates are activated
        if (plate1.IsActivated){
            OpenDoors1();
            OpenDoors3();
            CloseDoors2();
        }else{
            CloseDoors1();
            CloseDoors3();
            OpenDoors2();
        }

        // Open Door Functions
        void OpenDoors1(){
            door1.SetActive(false); // Deactivate the first door
        }
        void OpenDoors2(){
            door2.SetActive(false); // Deactivate the second door
        }
        void OpenDoors3(){
            door3.SetActive(false); //Deactivate the third door
        }

        // Close Door Functions
        void CloseDoors1(){
            door1.SetActive(true);
        }
        void CloseDoors2(){
            door2.SetActive(true);
        }
        void CloseDoors3(){
            door3.SetActive(true);
        }
    }
}