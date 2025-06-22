using UnityEngine;

// Herencia: Car hereda de TempleObject (clase base abstracta que hereda de MonoBehaviour)
public class Car : TempleObject
{
    // Encapsulamiento:
    private bool hasMoved = false;

    // Instanciación dinámica: referencia pública a un Spawner para pedir creación de otros objetos

    public Spawner spawner;


    // Método que implementa la interacción con el auto.
    // Este método está definido en la interfaz IInteractable y se sobreescribe aquí (Polimorfismo)
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
