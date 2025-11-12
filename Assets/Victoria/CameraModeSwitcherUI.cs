using UnityEngine;

public class CameraModeSwitcherUI : MonoBehaviour
{
    [Header("Objetivos")]
    public Transform target;
    public Transform pivot;

    [Header("Modo fija (normal)")]
    public Transform fixedCameraPosition;

    [Header("Modo tercera persona")]
    public float followDistance = 5f;
    public float followHeight = 2f;
    public float smoothSpeed = 0.1f;

    private bool thirdPersonActive = false;

    void Start()
    {
        if (fixedCameraPosition != null)
        {
            transform.position = fixedCameraPosition.position;
            transform.rotation = fixedCameraPosition.rotation;
        }
    }

    void LateUpdate()
    {
        if (thirdPersonActive)
        {
            if (pivot == null) return;

            Vector3 desiredPosition = pivot.position + Vector3.up * followHeight - pivot.forward * followDistance;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.LookAt(pivot.position);
        }
        else
        {
            if (fixedCameraPosition == null) return;

            transform.position = Vector3.Lerp(transform.position, fixedCameraPosition.position, smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, fixedCameraPosition.rotation, smoothSpeed);
        }
    }

    public void SetThirdPersonCamera(bool active)
    {
        thirdPersonActive = active;
    }

}
