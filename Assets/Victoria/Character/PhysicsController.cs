using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        // Obtener el componente Animator del personaje
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

        // Crear vector de movimiento y normalizarlo
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // Si hay movimiento, rotar el personaje en esa dirección
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }

        // Mover el personaje
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // Activar/desactivar animación Walk
        bool isWalking = move != Vector3.zero;

        if (animator != null)
            animator.SetBool("isWalking", isWalking);

    }
}
