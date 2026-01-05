using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float speed = 5f;
    public Transform model;

    private Vector3 moveInput;
    private bool isWalking;
    private bool canMove = false;

    public void SetCanMove(bool value)
    {
        canMove = value;
        if (!canMove)
        {
            moveInput = Vector3.zero;
            isWalking = false;
        }
    }

    void Update()
    {
        if (!canMove)
            return;

        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.A)) moveZ = -1f;
        if (Input.GetKey(KeyCode.D)) moveZ = 1f;
        if (Input.GetKey(KeyCode.W)) moveX = -1f;
        if (Input.GetKey(KeyCode.S)) moveX = 1f;

        moveInput = new Vector3(moveX, 0, moveZ).normalized;
        isWalking = moveInput != Vector3.zero;

        if (isWalking && model != null)
        {
            Quaternion look = Quaternion.LookRotation(moveInput);
            Quaternion offset = Quaternion.Euler(-90f, 180f, 0f);
            model.rotation = look * offset;
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        transform.Translate(moveInput * speed * Time.fixedDeltaTime, Space.World);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
