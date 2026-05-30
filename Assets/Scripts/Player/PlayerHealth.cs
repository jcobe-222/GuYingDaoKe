using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("血量")]
    public int maxHp = 5;
    public int currentHp;

    [Header("受击设置")]
    public float hurtTime = 0.2f;
    public float invincibleTime = 1f;

    public bool isHurt;
    public bool isInvincible;
    public bool isDead;
    private Animator anim;
    private SpriteRenderer sr;
    private Color originalColor;
    public Slider hpSlider;
    public GameObject gameOverUI;

    private void Start()
    {
        isDead = false;
        currentHp = maxHp;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        hpSlider.maxValue = maxHp;
        hpSlider.value = currentHp;
    }

    public void TakeDamage(int damage)
    {
        // 无敌时不受伤
        if (isInvincible||isDead)
        {
            return;
        }
        currentHp -= damage;
        hpSlider.value = currentHp;
        Debug.Log("玩家受伤，当前血量：" + currentHp);
        StartCoroutine(HurtCoroutine());
        PlayerAttack attack = GetComponent<PlayerAttack>();
        if (attack != null)
        {
            attack.ForceStopAttack();
        }
        if (currentHp <= 0)
        {
            Die();
        }
    }

    IEnumerator HurtCoroutine()
    {
        isHurt = true;
        isInvincible = true;
        // 播放受击动画
        anim.SetTrigger("Hurt");
        // 闪红
        sr.color = Color.red;
        yield return new WaitForSeconds(hurtTime);
        sr.color = originalColor;
        isHurt = false;
        // 继续无敌一小段时间
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
    void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        StopAllCoroutines();
        isInvincible = true;
        isHurt = false;
        PlayerAttack attack = GetComponent<PlayerAttack>();
        if (attack != null)
        {
            attack.ForceStopAttack();
        }
        anim.SetTrigger("Dead");
        gameOverUI.SetActive(true);
        Debug.Log("玩家死亡");
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
