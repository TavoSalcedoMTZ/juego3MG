public class ThirdPersonState : ICameraState
{
    public void Enter(CameraController cameraController)
    {
        // Re-enable the third-person camera controls
        cameraController.CanRotate(true);
    }

    public void Exit(CameraController cameraController)
    {
        // Optionally, you could disable third-person controls here if needed
        cameraController.CanRotate(false);
    }

    public void Update(CameraController cameraController)
    {
        // Keep rotating the camera in third person mode
        cameraController.Rotate();
        cameraController.FollowTarget();
    }
}
