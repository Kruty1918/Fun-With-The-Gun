using UnityEngine;

namespace Kruty1918
{
    public class SimplePlayerController : MonoBehaviour
    {
        [SerializeField] private CameraBase m_camera;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float runMultiplier = 1.5f;
        [SerializeField] private float jumpForce = 15f;
        [SerializeField] private float gravity = -20f;

        private CharacterController characterController;
        private Vector3 velocity;
        private float currentSpeed;
        private bool isRunning;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Перевірка на біг
            isRunning = Input.GetKey(KeyCode.LeftShift);

            // Розрахунок швидкості
            float targetSpeed = isRunning ? moveSpeed * runMultiplier : moveSpeed;

            if (horizontalInput != 0 || verticalInput != 0)
            {
                currentSpeed = targetSpeed;
            }
            else
            {
                currentSpeed = 0;
            }

            Vector3 move = new Vector3(horizontalInput * currentSpeed, 0, verticalInput * currentSpeed);

            bool isGrounded = characterController.isGrounded;

            // Обробка стрибка та гравітації
            if (isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    velocity.y = jumpForce; // Стрибок
                }
                else
                {
                    velocity.y = -1.5f; // Легка сила вниз, щоб запобігти зависанню
                }
            }
            else
            {
                velocity.y += gravity * Time.deltaTime; // Застосування гравітації
            }

            // Перевірка на зіткнення зі стелею
            if ((characterController.collisionFlags & CollisionFlags.Above) != 0)
            {
                velocity.y = -1.5f; // Миттєве падіння після зіткнення з стелею
            }

            move.y = velocity.y;

            // Переміщення персонажа
            characterController.Move(move * Time.deltaTime);

            // Оновлення камери
            m_camera.SetCameraZoom(new MovementData { CurrentSpeed = GetExactSpeed() });
        }




        public float GetExactSpeed()
        {
            // Повертаємо точну швидкість (лише горизонтальна швидкість)
            return new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;
        }
    }
}