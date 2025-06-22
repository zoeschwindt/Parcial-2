using UnityEngine;

// Clase Horse que hereda de TempleObject e implementa la interacción
public class Horse : TempleObject
{
    private AudioSource audioSource;

    // Propiedad privada que controla si el caballo puede relinchar
    private bool canNeigh = true;

    // Getter y setter para la propiedad canNeigh
    public bool CanNeigh
    {
        get { return canNeigh; }
        set { canNeigh = value; }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método que se llama al interactuar
    public override void Interact()
    {
        // Solo relincha si puede y no está ya sonando
        if (audioSource != null && !audioSource.isPlaying && CanNeigh)
        {
            audioSource.Play();
            Debug.Log("The horse neighs.");
        }
        else if (!CanNeigh)
        {
            Debug.Log("The horse is tired and won’t neigh.");
        }
    }
}
