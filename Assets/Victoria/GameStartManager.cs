using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameStartManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button buttonPhoto;

    [Header("Camera")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform cameraFollowPoint;
    [SerializeField] private Transform cameraFixedPoint;
    [SerializeField] private Transform cameraFirstPersonPoint;

    [Header("Player")]
    [SerializeField] private PhysicsController player;

    private bool isGameStarted = false;
    private bool isPaused = false;

    private enum CameraMode
    {
        ThirdPerson,
        Fixed,
        FirstPerson
    }

    private CameraMode currentCameraMode = CameraMode.ThirdPerson;

    void Start()
    {
        panelPause.SetActive(false);
        buttonPhoto.gameObject.SetActive(false);

        if (player != null)
            player.SetCanMove(false);

        if (buttonStart != null)
            buttonStart.onClick.AddListener(StartGame);
    }

    void Update()
    {
        if (!isGameStarted)
            return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    private void StartGame()
    {
        panelStart.SetActive(false);
        buttonPhoto.gameObject.SetActive(true);

        isGameStarted = true;

        if (player != null)
            player.SetCanMove(true);

        SetThirdPersonCamera();
    }

    private void PauseGame()
    {
        isPaused = true;
        panelPause.SetActive(true);
        Time.timeScale = 0f;

        if (player != null)
            player.SetCanMove(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        panelPause.SetActive(false);

        if (player != null)
            player.SetCanMove(true);
    }

    public void ChangeCamera()
    {
        switch (currentCameraMode)
        {
            case CameraMode.ThirdPerson:
                SetFixedCamera();
                currentCameraMode = CameraMode.Fixed;
                break;

            case CameraMode.Fixed:
                SetFirstPersonCamera();
                currentCameraMode = CameraMode.FirstPerson;
                break;

            case CameraMode.FirstPerson:
                SetThirdPersonCamera();
                currentCameraMode = CameraMode.ThirdPerson;
                break;
        }
    }

    private void SetThirdPersonCamera()
    {
        mainCamera.transform.SetParent(cameraFollowPoint);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    private void SetFixedCamera()
    {
        mainCamera.transform.SetParent(cameraFixedPoint);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    private void SetFirstPersonCamera()
    {
        mainCamera.transform.SetParent(cameraFirstPersonPoint);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
