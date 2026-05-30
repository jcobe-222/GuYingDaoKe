using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash设置")]
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;
    public float dashCooldown = 2f;
    [Header("无敌帧")]
    public bool isInvincible;
    // 是否正在Dash
    private bool isDashing;
    // 是否可以Dash
    private bool canDash = true;
    private Rigidbody2D rb;
    private Animator anim;
    // Dash方向
    private Vector2 dashDirection;
    public PlayerMotor motor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        DashInput();
        motor = GetComponent<PlayerMotor>();
    }
    // Dash输入
    void DashInput()
    {
        // 按K冲刺
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 正在冷却或正在Dash
            if (!canDash || isDashing)
            {
                return;
            }
            StartCoroutine(DashCoroutine());
        }
    }
    IEnumerator DashCoroutine()
    {
        // 进入Dash状态
        isDashing = true;
        // 进入冷却
        canDash = false;
        // 开启无敌帧
        isInvincible = true;
        // 播放Dash动画
        anim.SetTrigger("Dash");
        // 获取角色朝向
        float dir = transform.localScale.x;
        // Dash方向
        dashDirection = new Vector2(dir, 0);
        // 计时器
        float timer = 0;
        // Dash持续阶段
        while (timer < dashTime)
        {
            // 持续移动
            motor.Dash(dashDirection, dashSpeed);
            // 时间增加
            timer += Time.deltaTime;
            // 等下一帧
            yield return null;
        }
        // 停止移动
        rb.velocity = Vector2.zero;
        motor.Stop();
        // 关闭无敌帧
        isInvincible = false;
        // Dash结束
        isDashing = false;
        // 等待冷却时间
        yield return new WaitForSeconds(dashCooldown);
        // Dash恢复
        canDash = true;
    }
}
