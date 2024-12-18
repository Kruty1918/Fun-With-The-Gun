using UnityEngine;

namespace Kruty1918
{
    // Інтерфейс для отримання напрямку руху
    public interface IPlayerMovementInput
    {
        Vector2 GetInputAxis();  // Отримує напрямок руху
    }
}