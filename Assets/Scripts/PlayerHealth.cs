//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PlayerHealth : MonoBehaviour
//{
//    public int maxHealth = 100;
//    private int currentHealth;

//    void Start()
//    {
//        currentHealth = maxHealth;
//    }

//    void Update()
//    {
//        // daño de prueba 
//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            TakeDamage(10);
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;

//        Debug.Log("Jugador recibió daño: " + damage);
//        Debug.Log("Vida actual: " + currentHealth);

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        Debug.Log("El jugador murió");

//        // cargar menú principal
//        SceneManager.LoadScene("MainMenu");
//    }
//}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.LoseGame();
    }
}