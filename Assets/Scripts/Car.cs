using UnityEngine;

// La clase Car hereda de TempleObject, que es una clase base abstracta que hereda de MonoBehaviour.
// Esto nos permite compartir funcionalidades comunes entre todos los objetos del templo.
public class Car : TempleObject
{
    // Campo privado para controlar si el auto ya se movi� o no.
    private bool hasMoved = false;

    // Referencia p�blica a un spawner para que el auto pueda pedir que se cree otro objeto.
    // Esto permite la instanciaci�n din�mica de objetos durante la ejecuci�n del juego.

    public Spawner spawner;


    // M�todo que implementa la interacci�n con el auto.
    // Este m�todo est� definido en la interfaz IInteractable y se sobreescribe aqu�.
    public override void Interact()
    {
        // L�gica condicional: si el auto no se movi� todav�a, se mueve y se solicita al spawner que cree otro objeto.
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
