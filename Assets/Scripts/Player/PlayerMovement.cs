using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public GroundDetector groundDetector;

    public GameObject ArmaActiva1;
    public GameObject ArmaActiva2;  

    private Vector3 vectorMovement, verticalForce;
    private float targetSpeed, currentSpeed;
    private bool isGrounded, canMove;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        canMove = true;
        currentSpeed = 0f;
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckGround();
        Movement();
        ApplyGravity();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchArmas();
        }
    }

    public void Movement()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
    }

    public void Walk()
    {
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        vectorMovement = vectorMovement.normalized;
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * targetSpeed, 10f * Time.deltaTime);

        characterController.Move(vectorMovement * currentSpeed * Time.deltaTime);
    }

    public void Run()
    {
        if (Input.GetAxis("Run") > 0f)
        {
            targetSpeed = runSpeed;
        }
        else
        {
            targetSpeed = walkSpeed;
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce.y = jumpForce;
            isGrounded = false;
        }
    }

    public void ApplyGravity()
    {
        if (!isGrounded)
        {
           
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
           
            verticalForce.y = -2f;
        }

    
        characterController.Move(verticalForce * Time.deltaTime);
    }

    void AlignPlayer()
    {
        Vector3 cameraForward = cameraAim.forward;
        cameraForward.y = 0f; // Ignorar la inclinación vertical de la cámara

        if (cameraForward.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();

    
        if (characterController.isGrounded)
        {
            isGrounded = true;
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void CanMove(bool _state)
    {
        canMove = _state;
    }

    public void SwitchArmas()
    {
        if (ArmaActiva1.activeInHierarchy)
        {

            ArmaActiva1.SetActive(false);
            ArmaActiva2.SetActive(true);
        }
        else if (ArmaActiva2.activeInHierarchy)
        {
            ArmaActiva2 .SetActive(false);
            ArmaActiva1 .SetActive(true);   
        }
    }
    public void SetArma1(GameObject _arma)
    {
        if (ArmaActiva1.activeInHierarchy)
        {

            ArmaActiva1.SetActive(false);
            ArmaActiva1 = _arma;
            ArmaActiva1.SetActive(true);
        }
        else
        { 
            ArmaActiva1 = _arma;

        }
        }

    public void SetArma2(GameObject _arma)
    {
        if (ArmaActiva2.activeInHierarchy)
        {

            ArmaActiva2.SetActive(false);
            ArmaActiva2 = _arma;
            ArmaActiva2.SetActive(true);
        }
        else
        {
            ArmaActiva2          = _arma;

        }
    }
}
