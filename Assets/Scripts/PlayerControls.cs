using UnityEngine;

namespace Kruty1918
{
    public class PlayerControls
    {
        public IPlayerInput Input { get; }
        public Camera PlayerCamera { get; }

        public PlayerControls(IPlayerInput input, Camera playerCamera)
        {
            Input = input;
            PlayerCamera = playerCamera;
        }
    }
}