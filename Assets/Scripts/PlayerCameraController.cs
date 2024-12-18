using Cinemachine;
using UnityEngine;

namespace Kruty1918
{
    public class PlayerCameraController : CameraBase
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float speedFactor = 1f;
        [SerializeField] private float zoomSmoothing = 0.1f; // Час згладжування зуму
        [SerializeField] private float thresholdIn = 5;
        [SerializeField] private float maxFOV = 45;
        [SerializeField] private float minFOV = 25;

        private float initialFOV;
        private float targetFOV; // Цільовий FOV
        private float currentFOV; // Поточний FOV

        public override Camera Camera => _camera;

        private void Start()
        {
            initialFOV = virtualCamera.m_Lens.FieldOfView;
            currentFOV = initialFOV;
        }

        public override void SetCameraZoom(ISpeedSettings speedSettings, MovementData movementData)
        {
            // Якщо швидкість перевищує поріг
            if (movementData.CurrentSpeed >= thresholdIn)
            {
                targetFOV = initialFOV + (movementData.CurrentSpeed - thresholdIn) * speedFactor;
            }
            else
            {
                // Якщо швидкість нижча за поріг, повертаємо до початкового значення
                targetFOV = initialFOV;
            }

            // Згладжуємо перехід до цільового FOV
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime / zoomSmoothing);

            // Призначаємо новий FOV камері
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(currentFOV, minFOV, maxFOV);
        }
    }
}