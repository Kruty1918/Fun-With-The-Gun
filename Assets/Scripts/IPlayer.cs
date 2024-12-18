using UnityEngine;

namespace Kruty1918
{
    public interface IPlayer
    {
        CharacterController Controller { get; } // Контролер для руху
        PlayerControls Controls { get; }        // Управління введенням та камерою
    }
}