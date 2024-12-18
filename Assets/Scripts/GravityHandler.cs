using UnityEngine;

namespace Kruty1918
{
    public class GravityHandler : IGravityHandler
    {
        private readonly PlayerSettings playerSettings;
        private readonly PlayerControls playerControls;

        public GravityHandler(PlayerSettings playerSettings, PlayerControls playerControls)
        {
            this.playerSettings = playerSettings;
            this.playerControls = playerControls;
        }

        public void ApplyGravity(ref Vector3 velocity, IPlayer player)
        {
            // Перевіряємо, чи гравець на землі
            if (player.Controller.isGrounded)
            {
                // Якщо гравець на землі і вертикальна швидкість негативна, обнуляємо її
                if (velocity.y < 0)
                {
                    velocity.y = -0.5f; // Легке притискання до землі, щоб уникнути "залипання" в повітрі
                }

                // Обробляємо стрибок
                if (playerControls.Input.GetJump())
                {
                    velocity.y = Mathf.Sqrt(playerSettings.JumpSettings.JumpHeight * -2f * playerSettings.JumpSettings.Gravity);
                }
            }
            else
            {
                // Гравець у повітрі — додаємо гравітацію
                velocity.y += playerSettings.JumpSettings.Gravity * Time.fixedDeltaTime;
            }
        }
    }
}