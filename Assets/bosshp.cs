using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshp : MonoBehaviour
{
    public int damage = 10;
    private HealthManager healthManager;

    void Start()
    {
        // Find the health manager GameObject and get its HealthManager component
        healthManager = GameObject.FindObjectOfType<HealthManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if collided with player's weapon or another damaging object
        if (other.CompareTag("Bullet"))
        {
            // Deal damage to the enemy
            healthManager.TakeDamage(damage);
            Debug.Log("it hits");

        }
    }
}

