using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float sensitivity = 5f;
    public float distance = 5f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float zoomSpeed = 2f;
    public float runZoomAmount = -1.5f; // �޸� �� ���� �Ÿ�
    public float zoomSmoothSpeed = 5f;
    public float minY = -30f;
    public float maxY = 60f;
    public float followSmoothSpeed = 5f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool cursorLocked = true;
    private bool freeLook = false;
    private float targetDistance;

    void Start()
    {
        LockCursor(true);
        targetDistance = distance;
        rotationX = target.eulerAngles.y;
    }

    void Update()
    {
        // ���콺 Ŀ�� ���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor(cursorLocked);
        }

        // Alt Ű�� ���� ȸ�� ���
        freeLook = Input.GetKey(KeyCode.LeftAlt);

        if (cursorLocked && freeLook)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
        }
        else if (!freeLook)
        {
            // Alt Ű�� ���� �÷��̾� �������� ȸ�� ����
            rotationX = Mathf.LerpAngle(rotationX, target.eulerAngles.y, followSmoothSpeed * Time.deltaTime);
        }


        // ���콺 ȸ��
        if (cursorLocked)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
        }

        // ���콺 �� ��
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetDistance -= scroll * zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);

        // �޸��� ���¿� ���� �ڵ� ��
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float runOffset = isRunning ? runZoomAmount : 0f;
        float desiredDistance = Mathf.Clamp(targetDistance + runOffset, minDistance, maxDistance);
        distance = Mathf.Lerp(distance, desiredDistance, zoomSmoothSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance) + Vector3.up * offset.y;
        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * offset.y);
    }

    void LockCursor(bool lockCursor)
    {
        Cursor.visible = !lockCursor;
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
    }
}