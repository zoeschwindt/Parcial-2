using UnityEngine;

// Herencia: Chest hereda de TempleObject, que es una clase abstracta base para objetos interactuables
public class Chest : TempleObject
{
    // Encapsulamiento
    private int goldAmount;

    // Encapsulamiento y Propiedades (getters/setters) con l�gica para validar valores negativos
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

    // Inicializaci�n: m�todo Start para asignar valor inicial al oro cuando inicia el juego
    void Start()
    {
        GoldAmount = 100; 
    }

    // Polimorfismo: Override del m�todo abstracto Interact() definido en TempleObject
    // L�gica condicional: Comportamiento diferente seg�n si hay oro o no
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
