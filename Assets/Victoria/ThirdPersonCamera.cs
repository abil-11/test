using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform pivot;
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        if (pivot == null) return;

        Vector3 desiredPosition = pivot.position + Vector3.up * height - pivot.forward * distance;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.LookAt(pivot.position);
    }
}
