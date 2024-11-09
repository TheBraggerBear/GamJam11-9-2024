using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Vector3 cameraOffset; // Offset from the player's position

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = playerBody.position + cameraOffset; // Initial camera position
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation

        // Rotate the player body horizontally and the camera vertically
        playerBody.Rotate(Vector3.up * mouseX);

        // Update the camera's position to follow the player
        transform.position = playerBody.position + cameraOffset;

        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
