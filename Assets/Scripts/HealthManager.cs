using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
   
    
    public int maxHealth = 100;
    private int currentHealth;

    public Image Bossbar;

    // Initialize health
    void Start()
    {
        currentHealth = maxHealth;
       
    }

    // Decrease health when enemies take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("it hits");

        // Check if health reaches zero
        if (currentHealth <= 0)
        {
            // Implement death behavior here if needed
        }
        Bossbar.fillAmount = currentHealth / 30f;
    }

   
}
