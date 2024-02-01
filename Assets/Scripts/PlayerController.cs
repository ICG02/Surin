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
        // Проверка, находится ли персонаж на земле
        isGrounded = characterController.isGrounded;

        // Управление движением
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Применение движения
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Управление прыжком
        if (isGrounded)
        {
            playerVelocity.y = -2f; // сброс вертикальной скорости, если персонаж находится на земле

            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            }
        }

        // Применение гравитации
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
