public class NormalModeState : ICameraState
{
    public void Enter(CameraController cameraController)
    {
        // Activamos la rotación normal de la cámara
        cameraController.CanRotate(true);
    }

    public void Exit(CameraController cameraController)
    {
        // Desactivamos la rotación al salir del modo normal
        cameraController.CanRotate(false);
    }

    public void Update(CameraController cameraController)
    {
        // Actualizamos la rotación de la cámara y seguimos al objetivo en el modo normal
        cameraController.Rotate();
        cameraController.FollowTarget();
    }
}
