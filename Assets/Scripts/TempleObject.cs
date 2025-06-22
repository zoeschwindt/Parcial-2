using UnityEngine;

public abstract class TempleObject : MonoBehaviour, IInteractable
{
    public abstract void Interact(); // Obligamos a las clases hijas a implementar Interact
}