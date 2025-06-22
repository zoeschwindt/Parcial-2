using UnityEngine;

//Interfaz IInteractable: define una estructura común que obliga a implementar el método Interact().
// Se utiliza para aplicar polimorfismo: cualquier clase que implemente esta interfaz
public interface IInteractable
{
    // Método que deben implementar todas las clases que quieran ser "interactuables".
    void Interact();
}
