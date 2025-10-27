using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class IceSlider : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 slideDirection;
    private float slideSpeed;
    private float slideTimer;
    private bool isSliding;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isSliding)
        {
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0f)
            {
                isSliding = false;
            }
        }
    }

    public void StartSliding(float speed, float duration)
    {
        // 마지막 입력 방향 기준
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (inputDir != Vector3.zero)
        {
            slideDirection = transform.TransformDirection(inputDir);
            slideSpeed = speed;
            slideTimer = duration;
            isSliding = true;
        }
    }
}