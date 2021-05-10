using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 2.5f;
    [SerializeField] bool lockCursor = true;
    public float walkSpeed = 10.0f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.1f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] float jumpHeight = 2.0f;
    [SerializeField] float fallMultiplier = 2.5f;
    bool doubleJump = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    public CharacterController controller = null;

    public Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    public Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    public Vector3 dashDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateMouseLook();
        updateMovement();
    }

    void updateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void updateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();   //Inhibits diagonal vectors from adding to higher values, removing could help implement strafe jumping
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
        {
            velocityY = 0.0f;
            doubleJump = true;
        }
        velocityY += gravity * Time.deltaTime;

        if(velocityY < 0)   //code for faster falling, so less floaty
        {
            velocityY += (fallMultiplier - 1) * Time.deltaTime * gravity;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)   //Implements jump
        {
            FindObjectOfType<AudioManager>().Play("JumpSound");
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (Input.GetButtonDown("Jump") && !controller.isGrounded && doubleJump)   //Implements double jump
        {
            FindObjectOfType<AudioManager>().Play("JumpSound");
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
        }

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
        dashDir = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
    }
}
