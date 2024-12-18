using UnityEngine;

namespace Kruty1918
{
    public class MovementService : IMovementService
    {
        private readonly IMovementHandler movementHandler;
        private readonly IGravityHandler gravityHandler;
        private readonly IVelocityCalculator velocityCalculator;
        private readonly PlayerSettings playerSettings;
        private readonly PlayerControls playerControls;

        public MovementService(
            IMovementHandler movementHandler,
            IGravityHandler gravityHandler,
            IVelocityCalculator velocityCalculator,
            PlayerSettings playerSettings,
            PlayerControls playerControls)
        {
            this.movementHandler = movementHandler;
            this.gravityHandler = gravityHandler;
            this.velocityCalculator = velocityCalculator;
            this.playerSettings = playerSettings;
            this.playerControls = playerControls;
        }

        public void HandleMovement(IPlayer player, Vector3 moveInput, ref Vector3 velocity)
        {
            Vector3 moveDirection = Quaternion.Euler(0, playerControls.PlayerCamera.transform.eulerAngles.y, 0)
                                    * new Vector3(moveInput.x, 0, moveInput.y);

            if (playerSettings.AxisControl.FreezeZ)
                moveDirection.z = 0;

            if (player.Controller.isGrounded)
                movementHandler.HandleGroundMovement(moveDirection, ref velocity);
            else
                movementHandler.HandleAirMovement(moveDirection, ref velocity);

            gravityHandler.ApplyGravity(ref velocity, player);
            velocityCalculator.CalculateVelocity(moveDirection, ref velocity, playerSettings.SmoothnessSettings.PlayerSmooth, playerSettings.AxisControl.FreezeZ);
        }
    }
}