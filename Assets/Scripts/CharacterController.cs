using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 5.0f;
    public float SpeedRotation = 200.0f;
    public float mouseSensitivity = 2.0f;
    float x, y;
    float rotationX = 0.0f;
    Animator animator;
    public Rigidbody rb;
    public float jumpHeight = 8;
    bool isGrounded;
    public bool canJump;
    public Transform cameraTransform;

    private void Awake() 
    {
        // Restringir y ocultar el puntero del mouse en el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        canJump = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        RotateCamera();
        animator.SetFloat("VeltX", x);
        animator.SetFloat("VeltY", y);

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
                animator.SetBool("IsGround", true);
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
            animator.SetBool("IsGround", true);
        }
        else
        {
            Falling();
        }
    }

    void MoveCharacter()
    {
        transform.Rotate(0, x * Time.deltaTime * SpeedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(0, mouseX, 0);
    }

    public void Falling()
    {
        animator.SetBool("IsGround", false);
        animator.SetBool("Jump", false);
    }
}
