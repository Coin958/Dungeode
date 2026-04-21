//using UnityEngine;

//public class GolemPlayerController : MonoBehaviour
//{
//    public float walkSpeed = 2f;
//    public float runSpeed = 4f;
//    public float gravity = -20f;

//    private CharacterController controller;
//    private Animator animator;

//    private Vector3 verticalVelocity;

//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        animator = GetComponent<Animator>();
//        animator.SetFloat("Speed", 0f);
//    }

//    void Update()
//    {
//        Move();
//    }

//    void Move()
//    {
//        float h = Input.GetAxisRaw("Horizontal");
//        float v = Input.GetAxisRaw("Vertical");

//        Vector3 input = new Vector3(h, 0f, v).normalized;

//        if (controller.isGrounded && verticalVelocity.y < 0)
//        {
//            verticalVelocity.y = -1f;
//        }

//        verticalVelocity.y += gravity * Time.deltaTime;

//        bool isMoving = input.magnitude > 0f;
//        bool isRunning = Input.GetKey(KeyCode.LeftShift);

//        float currentSpeed = isRunning ? runSpeed : walkSpeed;
//        Vector3 horizontalMove = input * currentSpeed;

//        Vector3 finalMove = horizontalMove;
//        finalMove.y = verticalVelocity.y;

//        controller.Move(finalMove * Time.deltaTime);

//        if (!isMoving)
//        {
//            animator.SetFloat("Speed", 0f);
//        }
//        else if (isRunning)
//        {
//            animator.SetFloat("Speed", 1f);
//        }
//        else
//        {
//            animator.SetFloat("Speed", 0.5f);
//        }

//        if (input != Vector3.zero)
//        {
//            transform.forward = input;
//        }
//    }
//}

using UnityEngine;

public class GolemPlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float gravity = -20f;
    public float jumpForce = 2f;

    [Header("Cámara")]
    public Transform cameraPivot;

    private CharacterController controller;
    private Animator animator;

    private Vector3 velocity;

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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Movimiento relativo a cámara
        Vector3 forward = cameraPivot.forward;
        Vector3 right = cameraPivot.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * z + right * x;

        bool isMoving = move.magnitude > 0.1f;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Rotación hacia donde se mueve
        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // Movimiento horizontal
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Animaciones
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
    }
}