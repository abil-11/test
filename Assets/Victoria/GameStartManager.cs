using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject panelStart;
    [SerializeField] private Button buttonStart;

    [Header("Camera Control")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform cameraFollowPoint;

    [Header("Player Control")]
    [SerializeField] private MonoBehaviour[] playerScripts;

    private Vector3 cameraInitialPosition;
    private Quaternion cameraInitialRotation;

    private void Start()
    {
        cameraInitialPosition = mainCamera.transform.position;
        cameraInitialRotation = mainCamera.transform.rotation;

        SetPlayerControl(false);

        if (buttonStart != null)
        {
            buttonStart.onClick.AddListener(StartGame);
        }
    }

    private void StartGame()
    {
        if (panelStart != null)
        {
            panelStart.SetActive(false);
        }

        SetPlayerControl(true);

        MoveCameraToFollowPoint();
    }

    private void SetPlayerControl(bool isActive)
    {
        foreach (var script in playerScripts)
        {
            if (script != null)
            {
                script.enabled = isActive;
            }
        }
    }

    private void MoveCameraToFollowPoint()
    {
        if (cameraFollowPoint != null)
        {
            mainCamera.transform.SetParent(cameraFollowPoint);
            mainCamera.transform.localPosition = Vector3.zero;
            mainCamera.transform.localRotation = Quaternion.identity;
        }
    }

    public void ResetToMenu()
    {
        if (panelStart != null)
        {
            panelStart.SetActive(true);
        }

        SetPlayerControl(false);

        mainCamera.transform.SetParent(null);
        mainCamera.transform.position = cameraInitialPosition;
        mainCamera.transform.rotation = cameraInitialRotation;
    }
}