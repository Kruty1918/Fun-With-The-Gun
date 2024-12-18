using UnityEngine;

namespace Kruty1918
{
    public class DefaultMoveController : ICharacterMove
    {
        private readonly IMovementService movementService;
        private readonly IPlayer player;
        private Vector3 velocity;

        public DefaultMoveController(IMovementService movementService, IPlayer player)
        {
            this.movementService = movementService;
            this.player = player;
        }

        public void Move(out MovementData movementData)
        {
            Vector2 moveInput = player.Controls.Input.GetInputAxis();
            movementService.HandleMovement(player, new Vector3(moveInput.x, 0, moveInput.y), ref velocity);

            Vector3 finalMove = velocity * Time.fixedDeltaTime;
            player.Controller.Move(finalMove);

            movementData = new MovementData(new Vector3(velocity.x, 0, velocity.z), velocity.magnitude);
        }
    }
}