using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;          // Скорость передвижения игрока
    public float jumpForce = 10f;     // Сила прыжка

    void Update()
    {
        // Получаем ввод от игрока по горизонтали и вертикали
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Создаем вектор направления на основе ввода
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Нормализуем вектор направления, чтобы движение в диагональных направлениях не было быстрее
        movement.Normalize();

        // Перемещаем игрока
        transform.Translate(movement * speed * Time.deltaTime);

        // Обработка прыжка
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Приложим силу прыжка к игроку
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
