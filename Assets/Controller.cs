using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public float crouchSpeed = 2.5f;
    public float jumpHeight = 2f;

    [Header("Physics")]
    public float gravity = -25f; // Heavier gravity feels better in FPS
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Crouch Settings")]
    public float standingHeight = 2f;
    public float crouchHeight = 1f;
    public float cameraStandHeight = 0.8f; // Camera Y position when standing
    public float cameraCrouchHeight = 0.2f; // Camera Y position when crouching

    [Header("References")]
    public CharacterController controller;
    public Transform playerCamera;
    public float mouseSensitivity = 200f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (controller == null) controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground Check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        HandleLook();
        HandleMovement();
        HandleJump();
        HandleCrouch();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // SPRINT LOGIC: If holding LeftControl, use sprintSpeed
        float currentSpeed = walkSpeed;
        if (Input.GetKey(KeyCode.LeftControl)) currentSpeed = sprintSpeed;
        //if (Input.GetKey(KeyCode.LeftShift)) currentSpeed = crouchSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        // controller.Move(move * currentSpeed * Time.deltaTime);

        this.transform.position += move * currentSpeed * Time.deltaTime;
        // Apply Gravity
        velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
    }

    void HandleJump()
    {
        // Default Unity "Jump" is Space Bar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void HandleCrouch()
    {
        // CROUCH LOGIC: Shrink the controller AND move the camera
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            controller.height = crouchHeight;
            playerCamera.localPosition = new Vector3(0, cameraCrouchHeight, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            controller.height = standingHeight;
            playerCamera.localPosition = new Vector3(0, cameraStandHeight, 0);
        }
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}