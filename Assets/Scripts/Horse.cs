using UnityEngine;

// Herencia: la clase Horse hereda de TempleObject, una clase base abstracta.
public class Horse : TempleObject
{
    // Encapsulamiento: componente privado para reproducir sonido.
    private AudioSource audioSource;

    // Encapsulamiento: propiedad privada para controlar si el caballo puede relinchar o no.
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

    //Polimorfismo: se sobreescribe el método Interact() definido en la clase abstracta TempleObject.
    public override void Interact()
    {
        // Lógica condicional: reproduce sonido solo si puede relinchar y no está ya sonando.
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
