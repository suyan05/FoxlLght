using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public int maxJumpCount = 2;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private int jumpCount = 0;
    private bool isRunning = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �ٴ� üũ
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            jumpCount = 0;
        }

        // �޸��� �Է�
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // �̵� �Է�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection;

        if (vertical < 0)
        {
            // �ڷ� �Է� �� �ݴ� �������� �̵�
            moveDirection = -camForward * Mathf.Abs(vertical) + camRight * horizontal;
        }
        else
        {
            moveDirection = camForward * vertical + camRight * horizontal;
        }

        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // ����
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpCount++;
        }

        // �߷�
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}