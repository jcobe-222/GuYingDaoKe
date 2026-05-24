using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("µ–»ÀÀ¿Õˆ");
        GameEvents.EnemyKilled();  
        Destroy(gameObject);
    }
}
