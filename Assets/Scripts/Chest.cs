using UnityEngine;

// Herencia: Chest hereda de TempleObject, que es una clase abstracta base para objetos interactuables
public class Chest : TempleObject
{
    // Encapsulamiento
    private int goldAmount;

    // Encapsulamiento y Propiedades (getters/setters) con lógica para validar valores negativos
    public int GoldAmount
    {
        get { return goldAmount; }
        set
        {
            if (value >= 0) 
            {
                goldAmount = value;
            }
        }
    }

    // Inicialización: método Start para asignar valor inicial al oro cuando inicia el juego
    void Start()
    {
        GoldAmount = 100; 
    }

    // Polimorfismo: Override del método abstracto Interact() definido en TempleObject
    // Lógica condicional: Comportamiento diferente según si hay oro o no
    public override void Interact()
    {
        if (GoldAmount > 0)
        {
            Debug.Log($"You opened the chest and got {GoldAmount} gold!");
            GoldAmount = 0; // El cofre se vacía después de ser abierto
        }
        else
        {
            Debug.Log("The chest is empty.");
        }
    }
}
