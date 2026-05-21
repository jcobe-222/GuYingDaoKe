using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform attackPoint;
    public float attackRange=1;
    public LayerMask enemyLayers;
    public int attackDamage=1;
    Animator animator;
    private void Attack()
    {
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log(hitEnemies.Length);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("¹¥»÷");
            Attack();
            animator.SetTrigger("Attack");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
