using UnityEngine;

namespace Kruty1918
{
    public abstract class CameraBase : MonoBehaviour
    {
        public abstract Camera Camera { get; }
        public abstract void SetCameraZoom(ISpeedSettings speedSettings, MovementData movementData);
    }
}