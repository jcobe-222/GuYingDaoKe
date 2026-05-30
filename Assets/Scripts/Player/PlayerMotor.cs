using UnityEngine;
public class PlayerMotor: MonoBehaviour
{
    private Rigidbody2D rb;
    // 当前是否锁定移动
    public bool lockMovement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // 普通移动
    public void Move(Vector2 direction, float speed)
    {
        // 被锁定时不能移动
        if (lockMovement)
        {
            return;
        }

        rb.velocity = direction * speed;
    }
    // Dash移动
    public void Dash(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }
    // 停止移动
    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
    // 击退
    public void Knockback(Vector2 force)
    {
        rb.velocity = force;
    }
}