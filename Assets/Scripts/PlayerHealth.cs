using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    // Encapsulamiento
    [SerializeField] private int health = 5;
    public int CurrentHealth => health;

    // Método para recibir daño
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Player took damage. Current health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Cuando muere se reinicia la escena.
    private void Die()
    {
        Debug.Log("The player died, the scene restarts");
        SceneManager.LoadScene("Nivel");
    }
}
