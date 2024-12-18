namespace Kruty1918
{
    // Інтерфейс для налаштувань базової швидкості та її модифікаторів
    public interface ISpeedSettings
    {
        float PlayerSpeed { get; }
        float RunSpeedMultiplier { get; }
        float DashSpeed { get; } // Швидкість дашу
        float MaxAirSpeed { get; }
    }
}