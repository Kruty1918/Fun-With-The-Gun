using UnityEngine;

namespace Kruty1918
{
    public class GroundMovementHandler : IMovementHandler
    {
        private readonly PlayerSettings playerSettings;
        private readonly PlayerControls playerControls;

        public GroundMovementHandler(PlayerSettings playerSettings, PlayerControls playerControls)
        {
            this.playerSettings = playerSettings;
            this.playerControls = playerControls;
        }

        public void HandleGroundMovement(Vector3 moveDirection, ref Vector3 velocity)
        {
            float targetSpeed = playerControls.Input.GetRunning()
                ? playerSettings.SpeedSettings.PlayerSpeed * playerSettings.SpeedSettings.RunSpeedMultiplier
                : playerSettings.SpeedSettings.PlayerSpeed;

            float smoothTime = playerControls.Input.GetRunning()
                ? playerSettings.SmoothnessSettings.RunInOutSmooth
                : playerSettings.SmoothnessSettings.PlayerSmooth;

            if (moveDirection.magnitude > 0.01f)
            {
                velocity.x = Mathf.Lerp(velocity.x, moveDirection.x * targetSpeed, Time.fixedDeltaTime / smoothTime);
                velocity.z = playerSettings.AxisControl.FreezeZ ? 0 : Mathf.Lerp(velocity.z, moveDirection.z * targetSpeed, Time.fixedDeltaTime / smoothTime);
            }
            else
            {
                velocity.x = Mathf.Lerp(velocity.x, 0, Time.fixedDeltaTime / smoothTime);
                velocity.z = playerSettings.AxisControl.FreezeZ ? 0 : Mathf.Lerp(velocity.z, 0, Time.fixedDeltaTime / smoothTime);
            }
        }

        public void HandleAirMovement(Vector3 moveDirection, ref Vector3 velocity)
        {
            float airControlFactor = playerSettings.SmoothnessSettings.AirControlFactor;

            // Зберігаємо поточну горизонтальну швидкість
            Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);

            // Обчислюємо вплив введення
            Vector3 inputVelocity = new Vector3(moveDirection.x, 0, moveDirection.z) * playerSettings.SpeedSettings.PlayerSpeed;

            // Плавно додаємо швидкість введення (без різкого гальмування)
            horizontalVelocity += inputVelocity * airControlFactor * Time.fixedDeltaTime;


            // Оновлюємо горизонтальні складові швидкості
            velocity.x = horizontalVelocity.x;
            velocity.z = horizontalVelocity.z;

            // Додаємо гравітацію до вертикальної швидкості
            velocity.y += playerSettings.JumpSettings.Gravity * Time.fixedDeltaTime;
        }
    }
}