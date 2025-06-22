using UnityEngine;

// La clase Car hereda de TempleObject, que es una clase base abstracta que hereda de MonoBehaviour.
// Esto nos permite compartir funcionalidades comunes entre todos los objetos del templo.
public class Car : TempleObject
{
    // Campo privado para controlar si el auto ya se movió o no.
    private bool hasMoved = false;

    // Referencia pública a un spawner para que el auto pueda pedir que se cree otro objeto.
    // Esto permite la instanciación dinámica de objetos durante la ejecución del juego.

    public Spawner spawner;


    // Método que implementa la interacción con el auto.
    // Este método está definido en la interfaz IInteractable y se sobreescribe aquí.
    public override void Interact()
    {
        // Lógica condicional: si el auto no se movió todavía, se mueve y se solicita al spawner que cree otro objeto.
        if (!hasMoved)
        {
            transform.Translate(Vector3.forward * 2f);
            hasMoved = true;
            Debug.Log("The car has moved forward.");

            // Avisar al spawner que cree el caballo
            if (spawner != null)
            {
                spawner.SpawnObject();
            }
            else
            {
                Debug.LogWarning("Spawner reference not set on Car.");
            }
        }
        else
        {
            Debug.Log("Car already moved, no spawn.");
        }
    }
}
