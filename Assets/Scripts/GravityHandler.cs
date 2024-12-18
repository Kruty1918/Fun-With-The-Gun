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
            if (player.Controller.isGrounded)
            {
                if (velocity.y < 0)
                {
                    velocity.y = -2f;
                }

                if (playerControls.Input.GetJump())
                {
                    velocity.y = Mathf.Sqrt(playerSettings.JumpSettings.JumpHeight * -2f * playerSettings.JumpSettings.Gravity);
                }
            }
            else
            {
                velocity.y += playerSettings.JumpSettings.Gravity * Time.fixedDeltaTime;
            }
        }
    }
}