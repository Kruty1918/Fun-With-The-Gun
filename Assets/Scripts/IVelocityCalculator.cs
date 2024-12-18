using UnityEngine;

namespace Kruty1918
{
    public interface IVelocityCalculator
    {
        void CalculateVelocity(Vector3 targetVelocity, ref Vector3 velocity, float smoothingTime, bool freezeZ);
    }
}