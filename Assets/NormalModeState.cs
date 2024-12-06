public class NormalModeState : ICameraState
{
    public void Enter(CameraController cameraController)
    {
        // Activamos la rotaci�n normal de la c�mara
        cameraController.CanRotate(true);
    }

    public void Exit(CameraController cameraController)
    {
        // Desactivamos la rotaci�n al salir del modo normal
        cameraController.CanRotate(false);
    }

    public void Update(CameraController cameraController)
    {
        // Actualizamos la rotaci�n de la c�mara y seguimos al objetivo en el modo normal
        cameraController.Rotate();
        cameraController.FollowTarget();
    }
}
