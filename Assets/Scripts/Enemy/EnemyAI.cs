using UnityEngine;
using System.Collections;
public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Hurt,
        Dead
    }
    public EnemyState currentState;
    [Header("受击硬直")]
    public bool isHurt;
    public float hurtTime = 0.4f;
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public float chaseDistance = 6f;
    public float attackDistance =0.5f;
    [Header("攻击设置")]
    public int damage = 1;
    public float attackCooldown = 1f;
    private float lastAttackTime;
    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection;
    private bool isAttacking;
    private void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {   
        if (player == null)
        {
            return;
        }
        if (isHurt)
        {
            return;
        }
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Hurt:
                break;
            case EnemyState.Dead:
                break;
        }
    // 动画速度
    anim.SetFloat("Speed",rb.velocity.magnitude);
        // 翻转
        Flip();
    }
    void ChasePlayer()
    {
        if (isAttacking)
        {
            return;
        }
        moveDirection =(player.position -transform.position).normalized;
        rb.velocity =moveDirection * moveSpeed;
    }
    void StopMove()
    {
        rb.velocity = Vector2.zero;
    }
    void Idle()
    {
        anim.SetFloat("Speed", rb.velocity.magnitude);
        float distance =Vector2.Distance(transform.position, player.position);
        // 发现玩家
        if (distance <= chaseDistance)
        {
            currentState = EnemyState.Chase;
        }
    }
    void Chase()
    {
        ChasePlayer();
        float distance =Vector2.Distance(transform.position, player.position);
        if (distance <= attackDistance)
        {
            currentState = EnemyState.Attack;

            Attack();
        }
    }
    void Attack()
    {
        // 停止移动
        StopMove();
        // 冷却中
        if (Time.time <lastAttackTime + attackCooldown)
        {
            return;
        }
        lastAttackTime = Time.time;
        isAttacking = true;
        // 播放攻击动画
        anim.SetTrigger("Attack");
        Debug.Log("敌人攻击");
        currentState = EnemyState.Idle;
    }
    // 动画事件调用
    public void DealDamage()
    {
        if (player == null)
        {
            return;
        }
        float distance =Vector2.Distance(transform.position,player.position);
        // 防止玩家跑远
        if (distance <= attackDistance)
        {
            PlayerHealth ph =player.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
        }
    }
    // 动画结束调用
    public void EndAttack()
    {
        isAttacking = false;
    }
    void Flip()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Hurt()
    {
        StartCoroutine(HurtCoroutine());
    }
    IEnumerator HurtCoroutine()
    {
        isAttacking = false;
        anim.Play("Idle");
        isHurt = true;
        yield return new WaitForSeconds(hurtTime);
        isHurt = false;
    }
    void EnableAttack()
    {
        return;
    }
    void DisableAttack()
    {
        return;
    }
    void EnableNextCombo()
    {
        return;
    }
}
