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

    // Input System
    [SerializeField] private InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction interactAction;

    private Vector2 moveInput;
    private Vector2 lookInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (inputActions == null)
        {
            Debug.LogError("InputActions no está asignado en el Inspector.");
            return;
        }

        var playerMap = inputActions.FindActionMap("Player");
        if (playerMap == null)
        {
            Debug.LogError("No se encontró el Action Map llamado 'Player'");
            return;
        }

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
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    void FixedUpdate()
    {
        
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        Vector3 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

    void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.Log("Raycast golpeó: " + hit.collider.name);

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null)
                interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                Debug.Log("Interactable encontrado, llamando a Interact");
                interactable.Interact();
            }
            else
            {
                Debug.Log("No se encontró componente IInteractable");
            }
        }
    }
}
