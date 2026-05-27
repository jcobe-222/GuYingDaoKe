using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("攻击碰撞器")]
    public Collider2D attackCollider;
    private Animator anim;
    // 当前连击段数
    private int comboIndex=0;
    // 是否正在攻击
    private bool isAttacking;
    // 是否允许下一段连击
    private bool canNextCombo;
    private void Start()
    {
        anim = GetComponent<Animator>();
        // 默认关闭攻击碰撞器
        attackCollider.enabled = false;
    }
    private void Update()
    {
        AttackInput();
    }
    // 攻击输入
    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // 第一刀
            if (!isAttacking)
            {
                StartAttack();
            }
            // 连击输入
            else if (canNextCombo)
            {
                canNextCombo = false;
                comboIndex++;
                // 最大二连
                if (comboIndex > 2)
                {
                    comboIndex = 2;
                }
                PlayAttack();
            }
        }
    }
    // 开始攻击
    void StartAttack()
    {
        isAttacking = true;
        comboIndex = 1;
        PlayAttack();
    }
    // 播放攻击动画
    void PlayAttack()
    {
        anim.SetTrigger("Attack" + comboIndex);
        Debug.Log("播放攻击：" + comboIndex);
    }
    // 开启下一段连击
    // 动画事件调用
    public void EnableNextCombo()
    {
        canNextCombo = true;
    }
    // 攻击结束
    // 动画事件调用
    public void EndAttack()
    {
        isAttacking = false;
        canNextCombo = false;
        comboIndex = 0;
        Debug.Log("攻击结束");
    }
    // 开启攻击判定
    // 动画事件调用
    public void EnableAttack()
    {
        attackCollider.enabled = true;
        Debug.Log("开启攻击判定");
    }
    // 关闭攻击判定
    // 动画事件调用
    public void DisableAttack()
    {
        attackCollider.enabled = false;
        Debug.Log("关闭攻击判定");
    }
}
