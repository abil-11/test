using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Animator animator; // Ref

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Leer entrada del teclado
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey("a"))
            moveX = -1f;
        if (Input.GetKey("d"))
            moveX = 1f;
        if (Input.GetKey("w"))
            moveZ = 1f;
        if (Input.GetKey("s"))
            moveZ = -1f;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }

        transform.Translate(move * speed * Time.deltaTime, Space.World);

        bool isWalking = move != Vector3.zero;

        if (animator != null)
            animator.SetBool("isWalking", isWalking);

    }
}
