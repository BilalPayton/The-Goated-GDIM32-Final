using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public PlayerHealthUI healthUI;

    void Start()
    {
        currentHealth = 50;
        healthUI.UpdateHealthUI(currentHealth, maxHealth);
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthUI.UpdateHealthUI(currentHealth, maxHealth);

        Debug.Log("Current Health: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        healthUI.UpdateHealthUI(currentHealth, maxHealth);

        Debug.Log("Current Health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Player Dead");
    }

}