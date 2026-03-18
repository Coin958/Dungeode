using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 70f);

        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}