using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensibility = 2f;
    public Transform cameraJointY;
    public Transform targetObject;

    private float xRotation, yRotation;
    private bool canRotate = true;

    public CinemachineVirtualCamera virtualCamera;
    private ICameraState currentState;

    // Variables para el suavizado del zoom
    private float targetCameraDistance; // Distancia objetivo del zoom
    private float currentVelocity = 0f; // Velocidad para SmoothDamp
    public float smoothTime = 0.2f; // Tiempo de suavizado

    // Ángulos de rotación prefijados para el estado Aiming
    public float aimingXRotation = 0f;
    public float aimingYRotation = 15f;

    private void Awake()
    {
        if (FindObjectsOfType<CameraController>().Length > 1)
            Destroy(gameObject);
    }

    private void Start()
    {
        SetState(new ThirdPersonState());
    }

    private void Update()
    {
        currentState?.Update(this);

        if (Input.GetButtonDown("Fire2")) // Cambiar el estado al hacer clic derecho
        {
            SwitchState();
        }

        if (canRotate) // Solo permite rotar si `canRotate` es verdadero
        {
            Rotate();
        }

        SmoothCameraZoom(); // Actualizar suavizado del zoom
    }

    private void SwitchState()
    {
        if (currentState is ThirdPersonState)
        {
            Debug.Log("Cambiando al estado de Aiming");
            SetState(new AimingState());
            canRotate = false; // Desactivar rotación
            AlignCameraToAimingView(); // Alinear cámara a la vista prefijada
        }
        else
        {
            Debug.Log("Cambiando al estado de Tercera");
            SetState(new ThirdPersonState());
            canRotate = true; // Reactivar rotación
        }
    }

    public void SetState(ICameraState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public void Rotate()
    {
        xRotation += Input.GetAxis("Mouse X") * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * sensibility;

        yRotation = Mathf.Clamp(yRotation, -65, 65);

        transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    public void FollowTarget()
    {
        if (targetObject)
            transform.position = targetObject.position;
    }

    public void CanRotate(bool _state)
    {
        canRotate = _state;
    }

    public void SetTarget(Transform _target)
    {
        targetObject = _target;
    }

    public void AdjustCinemachineFollowOffset(float newCameraDistance)
    {
        if (virtualCamera)
        {
            // Obtén el componente Cinemachine3rdPersonFollow
            var thirdPersonFollow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if (thirdPersonFollow)
            {
                targetCameraDistance = newCameraDistance; // Establece la distancia objetivo
            }
            else
            {
                Debug.LogError("No se encontró el componente Cinemachine3rdPersonFollow en la cámara virtual.");
            }
        }
        else
        {
            Debug.LogError("No se ha asignado ninguna cámara virtual.");
        }
    }

    private void SmoothCameraZoom()
    {
        if (virtualCamera)
        {
            // Obtén el componente Cinemachine3rdPersonFollow
            var thirdPersonFollow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if (thirdPersonFollow)
            {
                // Interpola suavemente hacia la distancia objetivo
                thirdPersonFollow.CameraDistance = Mathf.SmoothDamp(
                    thirdPersonFollow.CameraDistance,
                    targetCameraDistance,
                    ref currentVelocity,
                    smoothTime
                );
            }
        }
    }

    private void AlignCameraToAimingView()
    {
        // Fija la rotación de la cámara a los valores prefijados
        transform.rotation = Quaternion.Euler(0f, aimingXRotation, 0f);
        cameraJointY.localRotation = Quaternion.Euler(-aimingYRotation, 0f, 0f);
    }
}
