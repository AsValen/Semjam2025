using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CubeCamera : MonoBehaviour
{
    [SerializeField] private RobotGrab Grab;
    [SerializeField] private Transform Robot;
    [SerializeField] private Transform Cube;
    private CinemachineVirtualCamera vCam;

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Grab.magnetGrabState == true) {
            vCam.Follow = Cube;
            vCam.LookAt = Cube;
        } else {
            vCam.Follow = Robot;
            vCam.LookAt = Robot;
        }
        
    }
}
