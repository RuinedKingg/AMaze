using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentController : MonoBehaviour
{
    [Header("Movment parameters")]
    [SerializeField] private float walkSpeed = 1.0f;

    [Header("Look parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(0, 10)] private float rotationSpeedX = 0.5f;
    [SerializeField, Range(0, 180)] private float lowerLookClamp = 20f;
    [SerializeField, Range(0, 180)] private float upperLookClamp = 0f;

    private CharacterController characterController;
    private Camera playerCamera;
    private Animator animator;

    private Vector3 moveDirection;
    private Vector2 curentInput;

    private float curentCameraXRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("isMoving", true);

            if (curentCameraXRotation < lowerLookClamp)
            {
                curentCameraXRotation += rotationSpeedX;

                playerCamera.transform.localRotation = Quaternion.Euler(curentCameraXRotation, 0, 0);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);

            if (curentCameraXRotation > upperLookClamp)
            {
                curentCameraXRotation -= rotationSpeedX;

                playerCamera.transform.localRotation = Quaternion.Euler(curentCameraXRotation, 0, 0);
            }
        }

        HandleMovmentInput();
        HandleMouseLook();

        ApplyFinalMovment();
    }

    private void HandleMovmentInput()
    {
        curentInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkSpeed;

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * curentInput.x) + 
                        (transform.TransformDirection(Vector3.right) * curentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void ApplyFinalMovment()
    {
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
