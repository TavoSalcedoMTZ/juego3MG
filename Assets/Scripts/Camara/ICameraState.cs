public interface ICameraState
{
    void Enter(CameraController cameraController); // Al entrar en el estado
    void Exit(CameraController cameraController); // Al salir del estado
    void Update(CameraController cameraController); // Actualizar cada frame
}
