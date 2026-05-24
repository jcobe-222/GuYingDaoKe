using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [Header("攻击设置")]
    public Transform attackPoint;
    public float attackRadius = 1f;
    public int attackDamage = 1;
    public LayerMask enemyLayer;
    [Header("攻击冷却")]
    public float attackCooldown = 0.5f;
    private float lastAttackTime;
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        // 按下J攻击
        if (Input.GetKeyDown(KeyCode.J))
        {
            // 冷却判断
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                Debug.Log("玩家攻击");
                // 检测范围内敌人
                Collider2D[] hitEnemies =
                Physics2D.OverlapCircleAll
                (
                    attackPoint.position,
                    attackRadius,
                    enemyLayer
                );

                // 遍历所有敌人
                foreach (Collider2D enemyCollider in hitEnemies)
                {
                    EnemyHealth enemy =enemyCollider.GetComponent<EnemyHealth>();
                    if (enemy != null)
                    {
                        // 计算击退方向
                        Vector2 hitDirection =
                        (
                            enemy.transform.position -
                            transform.position
                        ).normalized;

                        // 敌人受伤
                        enemy.TakeDamage(attackDamage,hitDirection);
                    }
                }
            }
        }
    }
    // 显示攻击范围（Scene里可见）
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
}
