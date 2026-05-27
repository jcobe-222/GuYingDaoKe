using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 获取移动速度
        float speed = rb.velocity.magnitude;
        // 传给Animator
        anim.SetFloat("Speed", speed);
    }
    // 受伤动画
    public void PlayHurt()
    {
        anim.SetTrigger("Hurt");
    }
}
