using UnityEngine;

//Interfaz IInteractable: define una estructura com�n que obliga a implementar el m�todo Interact().
// Se utiliza para aplicar polimorfismo: cualquier clase que implemente esta interfaz
public interface IInteractable
{
    // M�todo que deben implementar todas las clases que quieran ser "interactuables".
    void Interact();
}
