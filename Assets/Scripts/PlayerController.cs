using UnityEngine;

namespace Kruty1918
{
    public class PlayerController : MonoBehaviour, IPlayer
    {
        [Header("Move Settings")]
        [SerializeField] private CharacterController controller;
        [SerializeField] private MovementSettings movementSettings;

        [Header("Effects")]
        [SerializeField] private CameraBase playerCamera;

        private PlayerControls playerControls;
        private PlayerSettings playerSettings;

        private ICharacterMove characterMove;

        public CharacterController Controller => controller;

        public PlayerControls Controls => playerControls ??= new PlayerControls(playerInput, playerCamera.Camera);
        public PlayerSettings PlayerSettings => playerSettings;

        private IPlayerInput playerInput;

        private void Awake()
        {
            InitializeDependencies();
        }

        private void InitializeDependencies()
        {
            playerInput = new KeyboardPlayerInput();
            playerSettings = new PlayerSettings(
                movementSettings,
                movementSettings,
                movementSettings,
                movementSettings
            );

            playerControls = new PlayerControls(playerInput, playerCamera.Camera);

            var movementServiceFabric = new MovementServiceFabric(this);
            var movementService = movementServiceFabric.CreateService();

            characterMove = new DefaultMoveController(movementService, this);
        }

        private void FixedUpdate()
        {
            characterMove.Move(out MovementData movementData);
            playerCamera.SetCameraZoom(movementSettings, movementData);
        }
    }
}