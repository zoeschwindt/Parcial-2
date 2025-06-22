using UnityEngine;
// Herencia: TempleObject hereda de MonoBehaviour.
// Abstracci�n: esta clase se declara como abstracta, por lo que no se puede instanciar directamente.
// Polimorfismo y Interfaces:  implementa la interfaz IInteractable, lo que obliga a definir el m�todo Interact.
public abstract class TempleObject : MonoBehaviour, IInteractable
{
    // Abstracci�n y Polimorfismo: m�todo abstracto que cada clase hija debe implementar con su propio comportamiento.
    // Esto permite que el jugador llame a Interact() sin saber exactamente con qu� objeto est� interactuando.
    public abstract void Interact(); // Obligamos a las clases hijas a implementar Interact
}