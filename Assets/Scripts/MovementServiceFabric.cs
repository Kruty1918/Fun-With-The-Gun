namespace Kruty1918
{
    public class MovementServiceFabric : IMovementServiceFabric
    {
        private readonly PlayerController playerController;

        public MovementServiceFabric(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public MovementService CreateService()
        {
            var movementHandler = new GroundMovementHandler(playerController.PlayerSettings, playerController.Controls);
            var gravityHandler = new GravityHandler(playerController.PlayerSettings, playerController.Controls);
            var velocityCalculator = new VelocityCalculator();

            return new MovementService(
                movementHandler,
                gravityHandler,
                velocityCalculator,
                playerController.PlayerSettings,
                playerController.Controls
            );
        }
    }
}