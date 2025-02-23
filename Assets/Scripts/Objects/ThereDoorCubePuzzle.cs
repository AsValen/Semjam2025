using UnityEngine;

public class ThreeDoorCubePuzzle : MonoBehaviour
{
   [SerializeField] private CubePressurePlate plate1;
   [SerializeField] private CubePressurePlate plate2;
   [SerializeField] private CubePressurePlate plate3;
   [SerializeField] private GameObject door1;
   [SerializeField] private GameObject door2;
   [SerializeField] private GameObject door3;

    void Start()
    {
        door1.SetActive(true);
        door2.SetActive(false);
        door3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(plate1.IsActivated) {
            OpenDoor1();
            OpenDoor3();
            CloseDoor2();
        } else {
            CloseDoor1();
            CloseDoor3();
            OpenDoor2();
        }
    }

    //Open
    private void OpenDoor1() {
        door1.SetActive(false);
    }
    private void OpenDoor2() {
        door2.SetActive(false);
    }
    private void OpenDoor3() {
        door3.SetActive(false);
    }

    //Close
    private void CloseDoor1() {
        door1.SetActive(true);
    }
    private void CloseDoor2() {
        door2.SetActive(true);
    }
    private void CloseDoor3() {
        door3.SetActive(true);
    }

}
