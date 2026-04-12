using UnityEngine;

public class GolemPlayerController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float gravity = -20f;

    private CharacterController controller;
    private Animator animator;

    private Vector3 verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0f);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v).normalized;

        if (controller.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -1f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        bool isMoving = input.magnitude > 0f;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        Vector3 horizontalMove = input * currentSpeed;

        Vector3 finalMove = horizontalMove;
        finalMove.y = verticalVelocity.y;

        controller.Move(finalMove * Time.deltaTime);

        if (!isMoving)
        {
            animator.SetFloat("Speed", 0f);
        }
        else if (isRunning)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0.5f);
        }

        if (input != Vector3.zero)
        {
            transform.forward = input;
        }
    }
}