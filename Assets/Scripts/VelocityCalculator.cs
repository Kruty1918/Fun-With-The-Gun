using UnityEngine;

namespace Kruty1918
{
    public class VelocityCalculator : IVelocityCalculator
    {
        public void CalculateVelocity(Vector3 targetVelocity, ref Vector3 velocity, float smoothingTime, bool freezeZ)
        {
            velocity.x = Mathf.Lerp(velocity.x, targetVelocity.x, Time.fixedDeltaTime / smoothingTime);
            velocity.z = freezeZ ? 0 : Mathf.Lerp(velocity.z, targetVelocity.z, Time.fixedDeltaTime / smoothingTime);

            if (targetVelocity.magnitude < 0.01f)
            {
                velocity.x = velocity.z = 0;
            }
        }
    }
}