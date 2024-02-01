using UnityEngine;

public class ThirdPersonPlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTransform;
    public CharacterController characterController;

    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float cameraFollowSpeed = 10f;
    public float cameraHeight = 2f;

    private Vector3 cameraOffset;

    void Start()
    {
        if (playerTransform == null || cameraTransform == null || characterController == null)
        {
            Debug.LogError("Assign player, camera, and character controller in the inspector!");
            return;
        }

        cameraOffset = cameraTransform.position - playerTransform.position;
    }

    void Update()
    {
        // Передвижение игрока
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        characterController.Move(playerTransform.TransformDirection(movement));

        // Поворот игрока
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 playerDirection = new Vector3(horizontalInput, 0f, verticalInput);
            Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Обновление позиции камеры от третьего лица
        Vector3 desiredCameraPosition = playerTransform.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredCameraPosition, cameraFollowSpeed * Time.deltaTime);
        cameraTransform.position = smoothedPosition;

        // Поддерживаем постоянную высоту камеры
        cameraTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y + cameraHeight, cameraTransform.position.z);

        // Вращение камеры вместе с игроком
        Quaternion playerRotation = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0);
        cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
    }
}
