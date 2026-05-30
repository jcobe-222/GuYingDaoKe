using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private PlayerMotor motor;
    private Animator anim;
    private Vector2 moveInput;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        InputMove();
        AnimationControl();
        Flip();
    }

    private void FixedUpdate()
    {
        motor.Move(moveInput, moveSpeed);
    }
    void InputMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(x, y).normalized;
    }

    void AnimationControl()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveInput.x));
    }

    void Flip()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
