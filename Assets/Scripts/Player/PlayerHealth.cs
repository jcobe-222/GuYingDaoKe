using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
[Header("hp")]
public int hp=5;
    public GameObject gameOverUI;
    public bool isDead;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("玩家受伤，当前血量：" + hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {   
        isDead = true;
        Debug.Log("玩家死亡");
        gameOverUI.SetActive(true);
    }
    public void DealDamage()
    {
        return;
    }
    public void EndAttack()
    {
        return;
    }
}
