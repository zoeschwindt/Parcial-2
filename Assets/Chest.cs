using UnityEngine;

// Clase que representa un cofre en el juego
// Esta clase hereda de TempleObject, que es una clase abstracta base para objetos interactuables
public class Chest : TempleObject
{
    // Propiedad privada que almacena la cantidad de oro
    private int goldAmount;

    // Getter y setter con l�gica para evitar valores negativos
    public int GoldAmount
    {
        get { return goldAmount; }
        set
        {
            if (value >= 0) // Validaci�n para proteger la propiedad
            {
                goldAmount = value;
            }
        }
    }

    // M�todo Start se usa para inicializar el objeto cuando inicia el juego
    void Start()
    {
        GoldAmount = 100; // Se asigna un valor inicial al oro
    }

    // M�todo que implementa la interacci�n con el cofre
    // Aplica l�gica condicional para verificar si tiene oro o no
    public override void Interact()
    {
        if (GoldAmount > 0)
        {
            Debug.Log($"You opened the chest and got {GoldAmount} gold!");
            GoldAmount = 0; // El cofre se vac�a despu�s de ser abierto
        }
        else
        {
            Debug.Log("The chest is empty.");
        }
    }
}
