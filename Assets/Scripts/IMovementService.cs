using UnityEngine;

namespace Kruty1918
{
    public interface IMovementService
    {
        void HandleMovement(IPlayer player, Vector3 moveInput, ref Vector3 velocity);
    }
}