using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private Camera mergedCamera;
    [SerializeField] private float mergeDistance = 5f; // Distance to merge cameras
    private const string MAIN_CAMERA = "MainCamera";
    private const string UNTAGGED = "Untagged";

    private bool isMerged = false;

    void Start()
    {
        mergedCamera.enabled = false; // Start with merged camera disabled
    }

    void Update()
    {
        float distance = Vector2.Distance(player1.position, player2.position);

        if (distance <= mergeDistance && !isMerged)
        {
            MergeCameras();
        }
        else if (isMerged)
        {
            // Check if players are outside merged camera's view
            if (IsOutsideCameraView(player1) || IsOutsideCameraView(player2))
            {
                SplitCameras();
            }
        }
    }

    private void MergeCameras()
    {
        isMerged = true;

        camera1.enabled = false;
        camera2.enabled = false;
        mergedCamera.enabled = true;

        // Set mergedCamera as the active camera
        mergedCamera.tag = MAIN_CAMERA;
        camera1.tag = UNTAGGED;
        camera2.tag = UNTAGGED;

        // Center merged camera between players (fix Y to 5)
        mergedCamera.transform.position = new Vector3(
            (player1.position.x + player2.position.x) / 2, // Center X
            5, // Keep Y at 5
            -10f // Keep Z at -10
        );
    }

    private void SplitCameras()
    {
        isMerged = false;

        camera1.enabled = true;
        camera2.enabled = true;
        mergedCamera.enabled = false;

        // Restore original cameras as MainCamera
        camera1.tag = MAIN_CAMERA;
        camera2.tag = MAIN_CAMERA;
        mergedCamera.tag = UNTAGGED;
    }

    private bool IsOutsideCameraView(Transform player)
    {
        Vector3 viewportPos = mergedCamera.WorldToViewportPoint(player.position);
        return viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1;
    }
}
