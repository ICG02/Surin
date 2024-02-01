using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private float playerHeight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHeight = characterController.height;
    }

    void Update()
    {
        // ��������, ��������� �� �������� �� �����
        isGrounded = characterController.isGrounded;

        // ���������� ���������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // ���������� ��������
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // ���������� �������
        if (isGrounded)
        {
            playerVelocity.y = -2f; // ����� ������������ ��������, ���� �������� ��������� �� �����

            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            }
        }

        // ���������� ����������
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
