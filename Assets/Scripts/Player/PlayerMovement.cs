using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    private SpriteRenderer sr;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // 获取输入
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        // 防止斜方向更快
        moveInput = moveInput.normalized;
        // 动画速度参数
        anim.SetFloat("Speed", moveInput.magnitude);
        // 左右翻转角色
        Flip();
    }
    private void FixedUpdate()
    {
        // Rigidbody移动
        rb.velocity = moveInput * moveSpeed;
    }

    void Flip()
    {
            // 向右
            if (moveInput.x > 0)
            {
                transform.localScale =
                new Vector3(1, 1, 1);
            }

            // 向左
            else if (moveInput.x < 0)
            {
                transform.localScale =
                new Vector3(-1, 1, 1);
            }
    }
}
