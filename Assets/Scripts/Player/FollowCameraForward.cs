using UnityEngine;

public class FollowCameraForward : MonoBehaviour
{
    void Update()
    {
        // Obtener la direcci�n forward de la c�mara principal
        Vector3 cameraForward = Camera.main.transform.forward;

        // Ignorar la componente Y para evitar que el objeto rote hacia arriba o abajo
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Ajustar la rotaci�n del objeto para que su forward coincida con el de la c�mara
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}