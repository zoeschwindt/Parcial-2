using UnityEngine;

// Herencia: Car hereda de TempleObject (clase base abstracta que hereda de MonoBehaviour)
public class Car : TempleObject
{
    // Encapsulamiento:
    private bool hasMoved = false;

    // Instanciaci�n din�mica: referencia p�blica a un Spawner para pedir creaci�n de otros objetos

    public Spawner spawner;


    // M�todo que implementa la interacci�n con el auto.
    // Este m�todo est� definido en la interfaz IInteractable y se sobreescribe aqu� (Polimorfismo)
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
    // Expresi�n lambda: se usa una funci�n an�nima para aplicar da�o al jugador si choca con el auto
    private void OnCollisionEnter(Collision collision)
    {
        // Definici�n de la lambda: recibe un PlayerHealth y le aplica da�o
        System.Action<PlayerHealth> damagePlayer = (hp) => hp.TakeDamage(1);

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                damagePlayer(health); 
            }
        }
    }
}

