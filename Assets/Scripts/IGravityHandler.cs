using UnityEngine;

namespace Kruty1918
{
    public interface IGravityHandler
    {
        void ApplyGravity(ref Vector3 velocity, IPlayer player);
    }
}