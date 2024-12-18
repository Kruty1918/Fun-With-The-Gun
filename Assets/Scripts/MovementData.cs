using UnityEngine;

namespace Kruty1918
{
    public class MovementData
    {
        public readonly Vector3 Direction;
        public readonly float CurrentSpeed;

        public MovementData(Vector3 direction, float currentSpeed)
        {
            this.Direction = direction;
            this.CurrentSpeed = currentSpeed;
        }
    }
}