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
    }

    private void SwitchState()
    {
        if (currentState is ThirdPersonState)
        {
            Debug.Log("Cambiando al estado de Aiming");
            SetState(new AimingState());
        }
        else
        {
            Debug.Log("Cambiando al estado de Tercera");
            SetState(new ThirdPersonState());
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

    public void AdjustCinemachineFollowOffset(Vector3 newOffset)
    {
        if (virtualCamera)
        {
            // Obtén el componente CinemachineTransposer
            var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer)
            {
                transposer.m_FollowOffset = newOffset; // Cambia la distancia de seguimiento aquí
            }
            else
            {
                Debug.LogError("No se encontró el componente CinemachineTransposer en la cámara virtual.");
            }
        }
    }
}
