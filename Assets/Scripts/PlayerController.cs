using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpForce = 2f;

    public Transform cameraPivot;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // dirección según cámara
        Vector3 forward = cameraPivot.forward;
        Vector3 right = cameraPivot.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // movimiento relativo a la cámara
        Vector3 move = forward * z + right * x;

        Vector3 cameraForward = cameraPivot.forward;
        cameraForward.y = 0f;

        if (cameraForward.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // movimiento
        controller.Move(move * speed * Time.deltaTime);

        // gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // salto
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}