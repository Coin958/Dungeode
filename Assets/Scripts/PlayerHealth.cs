using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // daño de prueba 
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Jugador recibió daño: " + damage);
        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador murió");

        // cargar menú principal
        SceneManager.LoadScene("MainMenu");
    }
}