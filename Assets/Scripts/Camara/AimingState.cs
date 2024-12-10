using UnityEngine;

public class AimingState : ICameraState
{
    public void Enter(CameraController cameraController)
    {
        Debug.Log("Entrando en AimingState");
        cameraController.CanRotate(false);

        // Cambiar distancia al apuntar
        cameraController.AdjustCinemachineFollowOffset(3f);
    }

    public void Exit(CameraController cameraController)
    {
        Debug.Log("Saliendo de AimingState");
        cameraController.CanRotate(true);

        cameraController.AdjustCinemachineFollowOffset(5f);
    }

    public void Update(CameraController cameraController)
    {
        cameraController.Rotate();
        cameraController.FollowTarget();
    }
}