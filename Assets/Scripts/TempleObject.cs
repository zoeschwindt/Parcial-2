using UnityEngine;
// Herencia: TempleObject hereda de MonoBehaviour.
// Abstracción: esta clase se declara como abstracta, por lo que no se puede instanciar directamente.
// Polimorfismo y Interfaces:  implementa la interfaz IInteractable, lo que obliga a definir el método Interact.
public abstract class TempleObject : MonoBehaviour, IInteractable
{
    // Abstracción y Polimorfismo: método abstracto que cada clase hija debe implementar con su propio comportamiento.
    // Esto permite que el jugador llame a Interact() sin saber exactamente con qué objeto está interactuando.
    public abstract void Interact(); // Obligamos a las clases hijas a implementar Interact
}