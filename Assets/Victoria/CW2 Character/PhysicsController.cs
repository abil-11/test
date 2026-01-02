using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey("a")) moveZ = -1f;
        if (Input.GetKey("d")) moveZ = 1f;
        if (Input.GetKey("w")) moveX = -1f;
        if (Input.GetKey("s")) moveX = 1f;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move != Vector3.zero)
        {
            Quaternion look = Quaternion.LookRotation(move);
            Quaternion offset = Quaternion.Euler(-90f, 180f, 0f); 
            transform.rotation = look * offset;
        }

        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (animator != null)
            animator.SetBool("isWalking", move != Vector3.zero);

    }
}
