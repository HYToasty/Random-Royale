using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerLook : MonoBehaviour
{
    public float mouseSens;
    float xRotation;
    public float speed;

    public Transform plrTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseSens = 640f;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        plrTransform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
