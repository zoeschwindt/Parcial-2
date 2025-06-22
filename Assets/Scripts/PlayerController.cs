using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private float rotationY = 0f;

    [Header("Interacción")]
    public float rayDistance = 2f;

    // Input System (Encapsulamiento con [SerializeField ] y campos privados)
    [SerializeField] private InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction interactAction;

    private Vector2 moveInput;
    private Vector2 lookInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Encapsulamiento: protegemos el acceso al mapa de controles
        if (inputActions == null)
        {
            Debug.LogError("InputActions no está asignado en el Inspector.");
            return;
        }
        // Buscamos el mapa de acciones "Player"
        var playerMap = inputActions.FindActionMap("Player");
        if (playerMap == null)
        {
            Debug.LogError("No se encontró el Action Map llamado 'Player'");
            return;
        }
        // Buscamos las acciones individuales
        moveAction = playerMap.FindAction("Move");
        lookAction = playerMap.FindAction("Look");
        interactAction = playerMap.FindAction("Interact");

        if (moveAction == null) Debug.LogError("No se encontró la acción 'Move'");
        if (lookAction == null) Debug.LogError("No se encontró la acción 'Look'");
        if (interactAction == null) Debug.LogError("No se encontró la acción 'Interact'");

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        lookAction.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        lookAction.canceled += ctx => lookInput = Vector2.zero;

        interactAction.performed += ctx => TryInteract();
    }

    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        interactAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();      
        lookAction.Disable();
        interactAction.Disable();
    }

    void Start()
    {
        // Bloqueamos rotación para que el Rigidbody no lo desacomode
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        // Ocultamos el cursor y lo bloqueamos
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Usamos el input del mouse para girar el jugador
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    void FixedUpdate()
    {
        // Dirección según la rotación del jugador 
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        Vector3 velocity = moveDirection * moveSpeed;

        // Encapsulamos la lógica de movimiento
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

    // Método para interactuar con objetos que implementan la interfaz IInteractable (polimorfismo).
   
    void TryInteract()
    {
        RaycastHit hit;
        // Lanza un rayo hacia adelante para detectar objetos
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

            // Aplicación de interfaz (Polimorfismo)
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null)
                interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                Debug.Log("Interactable found, calling Interact()");
                interactable.Interact();
            }
            else
            {
                Debug.Log("No IInteractable component found");
            }
        }
    }
}
