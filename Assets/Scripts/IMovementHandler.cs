using UnityEngine;

namespace Kruty1918
{
    public interface IMovementHandler
    {
        void HandleGroundMovement(Vector3 moveDirection, ref Vector3 velocity);
        void HandleAirMovement(Vector3 moveDirection, ref Vector3 velocity);
    }
}