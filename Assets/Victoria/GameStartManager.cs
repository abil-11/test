using UnityEngine;
using UnityEngine.UI;

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

    [Header("Player")]
    [SerializeField] private PhysicsController player;

    private bool isGameStarted = false;
    private bool isPaused = false;
    private bool usingFollowCamera = true;

    private Vector3 cameraInitialPosition;
    private Quaternion cameraInitialRotation;

    void Start()
    {
        cameraInitialPosition = mainCamera.transform.position;
        cameraInitialRotation = mainCamera.transform.rotation;

        panelPause.SetActive(false);
        buttonPhoto.gameObject.SetActive(false);

        if (player != null)
            player.SetCanMove(false);

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

        SetFollowCamera();
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
        isPaused = false;
        panelPause.SetActive(false);
        Time.timeScale = 1f;

        if (player != null)
            player.SetCanMove(true);
    }

    public void ChangeCamera()
    {
        if (usingFollowCamera)
            SetFixedCamera();
        else
            SetFollowCamera();

        usingFollowCamera = !usingFollowCamera;
    }

    private void SetFollowCamera()
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
