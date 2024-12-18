namespace Kruty1918
{
    public class PlayerSettings
    {
        public ISpeedSettings SpeedSettings { get; }
        public IJumpSettings JumpSettings { get; }
        public ISmoothnessSettings SmoothnessSettings { get; }
        public IAxisControlSettings AxisControl { get; }

        public PlayerSettings(ISpeedSettings speedSettings, IJumpSettings jumpSettings, ISmoothnessSettings smoothnessSettings, IAxisControlSettings axisControl)
        {
            SpeedSettings = speedSettings;
            JumpSettings = jumpSettings;
            SmoothnessSettings = smoothnessSettings;
            AxisControl = axisControl;
        }
    }
}