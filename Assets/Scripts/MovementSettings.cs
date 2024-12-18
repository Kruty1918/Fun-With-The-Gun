using UnityEngine;

namespace Kruty1918
{
    [System.Serializable]
    public class MovementSettings : ISpeedSettings, IJumpSettings, ISmoothnessSettings, IAxisControlSettings
    {
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float jumpHeight = 1.5f;
        [SerializeField] private float runSpeedMultiplier = 1.5f;
        [SerializeField] private float runInOutSmooth = 0.1f;
        [SerializeField] private float dashSpeed = 2;
        [SerializeField] private float playerSmooth = 0.35f;
        [SerializeField] private float airControlFactor = 0.5f;
        [SerializeField] private float maxAirSpeed = 3;
        [SerializeField] private bool freezeZ = true;

        public float PlayerSpeed => playerSpeed;
        public float Gravity => gravity;
        public float JumpHeight => jumpHeight;
        public float RunSpeedMultiplier => runSpeedMultiplier;
        public float DashSpeed => dashSpeed;
        public float PlayerSmooth => playerSmooth;
        public float AirControlFactor => airControlFactor;
        public float RunInOutSmooth => runInOutSmooth;
        public bool FreezeZ => freezeZ;
        public float MaxAirSpeed => maxAirSpeed;
    }
}