using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2;
    Animator animator;

    public float moveSpeed = 5f;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb2.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        bool isRunning = (moveX != 0 || moveY!=0);

        animator.SetBool("IsRunning", isRunning);
        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
