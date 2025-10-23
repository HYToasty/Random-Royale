using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float gCRadius;

    public bool grounded;

    public CharacterController controller;
    Vector3 velocity;
    public Transform groundCheck;
    public LayerMask gCFilter;

    private void Start()
    {
        speed = 2f;
        gravity = -19.62f;
        gCRadius = 0.4f;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        grounded = Physics.CheckSphere(groundCheck.position, gCRadius, gCFilter);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
