using UnityEngine;

namespace Kruty1918
{
    public class KeyboardPlayerInput : IPlayerInput
    {
        private float horizontalInput;
        private float verticalInput;
        private bool isJumping;
        private bool isRunning;
        private bool isSliding;
        private bool isDashing;
        private bool isAttacking;

        // Змінні для обробки подвійного натискання
        private float lastSpacePressTime = -1f;  // Час останнього натискання пробілу
        private const float doublePressThreshold = 0.15f; // Інтервал для подвійного натискання

        public Vector2 GetInputAxis()
        {
            UpdateInput();
            return new Vector2(horizontalInput, verticalInput);
        }

        public bool GetJump()
        {
            UpdateInput();
            return isJumping;
        }

        public bool GetRunning()
        {
            UpdateInput();
            return isRunning;
        }

        public bool GetSliding()
        {
            UpdateInput();
            return isSliding;
        }

        public bool GetDashing()
        {
            UpdateInput();
            return isDashing;
        }

        public bool GetAttacking()
        {
            UpdateInput();
            return isAttacking;
        }

        public void UpdateInput()
        {
            // Скидаємо значення вводу
            horizontalInput = 0f;
            verticalInput = 0f;
            isJumping = false;
            isRunning = false;
            isSliding = false;
            isDashing = false;
            isAttacking = false;

            // Рух персонажа
            if (Input.GetKey(KeyCode.W)) verticalInput = 1f;
            if (Input.GetKey(KeyCode.S)) verticalInput = -1f;
            if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
            if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;

            // Стрибок
            if (Input.GetKey(KeyCode.Space))
            {
                isJumping = true;
            }

            // Біг
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
            }

            // Підкат
            if (Input.GetKey(KeyCode.LeftControl))
            {
                isSliding = true;
            }

            // Атака
            if (Input.GetKeyDown(KeyCode.F))
            {
                isAttacking = true;
            }
        }
    }
}