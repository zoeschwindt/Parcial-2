using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Instanciación dinámica: este prefab se va a crear en tiempo de ejecución.
    public GameObject prefabToSpawn;

    // Lugar donde se va a instanciar el nuevo objeto.
    public Transform spawnPoint;

    // Encapsulamiento: variable privada que controla si ya se hizo un spawn o no.
    private bool hasSpawned = false;

    // Método público que permite crear el objeto si no se ha creado antes.
    // Aplica lógica condicional para controlar el comportamiento.
    public void SpawnObject()
    {
        if (!hasSpawned && prefabToSpawn != null && spawnPoint != null)
        {
            GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            hasSpawned = true;
            Debug.Log("Object spawned dynamically after Car interaction.");

            Horse horse = obj.GetComponent<Horse>();
            if (horse != null)
            {
                StartCoroutine(MakeHorseTiredAfterSeconds(horse, 40f));
            }
        }
        else if (hasSpawned)
        {
            Debug.Log("Spawner: object already spawned, skipping.");
        }
        else
        {
            Debug.LogWarning("Spawner: prefabToSpawn or spawnPoint is not assigned.");
        }
    }
    // Corrutina que espera un tiempo antes de modificar al objeto Horse.
    // Encapsulamiento: se accede a la propiedad CanNeigh a través del setter, no directamente.
    private System.Collections.IEnumerator MakeHorseTiredAfterSeconds(Horse horse, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        horse.CanNeigh = false;
        Debug.Log("The spawned horse is now tired and won’t neigh anymore.");
    }
}
