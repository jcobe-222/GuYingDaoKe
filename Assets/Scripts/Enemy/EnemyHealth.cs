using System.Collections;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [Header("血量")]
    public int hp = 3;
    [Header("受击闪白时间")]
    public float flashTime = 0.4f;
    [Header("击退力度")]
    public float knockbackForce = 5f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Color originalColor;
    private EnemyAI enemyAI;
    private void Start()
    {
        // 获取组件
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
        // 记录原始颜色
        originalColor = sr.color;
    }
    // 受伤函数
    public void TakeDamage(int damage, Vector2 hitDirection)
    {
        // 扣血
        hp -= damage;
        Debug.Log("敌人受伤，当前血量：" + hp);
        // 开始闪白
        StartCoroutine(HitFlash());
        // 击退
        Knockback(hitDirection);
        // 顿帧
        HitStop.Instance.StopTime(0.1f);
        enemyAI.Hurt();
        // 判断死亡
        if (hp <= 0)
        {
            Die();
        }
    }
    // 闪红协程
    IEnumerator HitFlash()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        sr.color = originalColor;
    }
    // 击退
    void Knockback(Vector2 direction)
    {
        rb.velocity = direction * 4f;
        StartCoroutine(StopKnockback());
    }
    IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(0.08f);
        rb.velocity = Vector2.zero;
    }
    // 死亡
    void Die()
    {
        Debug.Log("敌人死亡");
        Destroy(gameObject);
    }
}