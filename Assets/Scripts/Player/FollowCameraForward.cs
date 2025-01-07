using UnityEngine;

public class FollowCameraForward : MonoBehaviour
{
    void Update()
    {
        // Obtener la dirección forward de la cámara principal
        Vector3 cameraForward = Camera.main.transform.forward;

        // Ignorar la componente Y para evitar que el objeto rote hacia arriba o abajo
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Ajustar la rotación del objeto para que su forward coincida con el de la cámara
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}