using UnityEngine;

public class Car : TempleObject
{
    private bool hasMoved = false;

    public Spawner spawner; // Referencia pública al spawner

    public override void Interact()
    {
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
