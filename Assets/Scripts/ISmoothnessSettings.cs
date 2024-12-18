namespace Kruty1918
{
    // Інтерфейс для налаштувань плавності та контролю
    public interface ISmoothnessSettings
    {
        float PlayerSmooth { get; }       // Загальна плавність руху
        float AirControlFactor { get; }   // Контроль у повітрі
        float RunInOutSmooth { get; }     // Плавність переходу до бігу
    }
}