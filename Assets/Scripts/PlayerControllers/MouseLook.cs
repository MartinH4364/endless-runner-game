using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0f);

    }
}
