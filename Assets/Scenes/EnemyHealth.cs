using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth=3;
    int currentHealth;
    void Die()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    } 
}
