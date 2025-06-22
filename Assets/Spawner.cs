using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    private bool hasSpawned = false;

    
    void Start()
    {
        
    }

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

    private System.Collections.IEnumerator MakeHorseTiredAfterSeconds(Horse horse, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        horse.CanNeigh = false;
        Debug.Log("The spawned horse is now tired and won’t neigh anymore.");
    }
}
