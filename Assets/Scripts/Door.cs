using UnityEngine;
// Herencia: Door hereda de TempleObject, una clase base abstracta para objetos interactuables.
// Esto permite reutilizar código común y aplicar polimorfismo.
public class Door : TempleObject
{
    // Encapsulamiento: variable privada para controlar si la puerta ya fue abierta.
    private bool isOpen = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on Door");
        }
    }
    // Polimorfismo: se sobreescribe el método Interact(), definido en la clase base TempleObject.
    public override void Interact()
    {
        Debug.Log("Interact called on Door");
        if (!isOpen)
        {
            // Lógica condicional: si la puerta no está abierta, se abre.
            isOpen = true;
            animator.SetTrigger("Open");
        }
    }
}
