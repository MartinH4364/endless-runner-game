using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera mainCamera;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float jumpCost = 10;

    public Transform groundCheck;
    public float groundDistance = 0.05f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float stamina = 100;
    public float staminaRegenRate = 2;
    float speedMultiplier = 1;

    public float airResistance = 0.9f;
    public float slideDrag = 0.995f;

    bool previousGrounded = true;
    bool canJump = true;

    public float sprintStaminaDrain = 5;
    public float sprintMultiplier = 2;
    bool sprinting = false;
    bool sliding = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        handleJump();

        handleSlide();

        handleSprint();

        handleWalk();

        handleStamina();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);

        previousGrounded = isGrounded;

    }
    
    void handleJump()
    {
        if(isGrounded)
        {
            if(velocity.y < 0)
            {
                velocity.y = -0f;
            }

            if(Input.GetButton("Jump") && stamina >= jumpCost && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                stamina -= jumpCost;
                canJump = false;
            }
        } else
        {
            canJump = true;
        }
    }

    void handleWalk()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        if(!sliding){
            if(isGrounded)
            {
                velocity.z = Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * speed * speedMultiplier;
                velocity.x = Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * speed * speedMultiplier;
                velocity.z += Mathf.Sin(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * speed * speedMultiplier;
                velocity.x += Mathf.Cos(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * speed * speedMultiplier;
            } else
            {
                velocity.z = velocity.z + (((Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical) + Mathf.Sin(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal) * speed * speedMultiplier-velocity.z) * airResistance;
                velocity.x = velocity.x + (((Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical) + Mathf.Cos(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal) * speed * speedMultiplier-velocity.x) * airResistance;
            }
        }else
        {
            velocity.z *= slideDrag;
            velocity.x *= slideDrag;
        }
    }

    void handleStamina()
    {
        if(stamina < 100 && !sprinting)
        {
            stamina += staminaRegenRate * Time.deltaTime;
            if(stamina > 100)
            {
                stamina = 100;
            }
        }
    }

    void handleSprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina >= sprintStaminaDrain * Time.deltaTime * 2 && !sliding)
        {
            stamina -= sprintStaminaDrain * Time.deltaTime;
            speedMultiplier = sprintMultiplier;
            sprinting = true;
            mainCamera.fieldOfView = mainCamera.fieldOfView + (55-mainCamera.fieldOfView) * 0.025f; 
        } else
        {
            speedMultiplier =1;
            sprinting = false;
            mainCamera.fieldOfView = mainCamera.fieldOfView + (60-mainCamera.fieldOfView) * 0.025f;
        }
    }

    void handleSlide()
    {
        if (Input.GetKey(KeyCode.C))
        {
            sliding = true;
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (0.3f-mainCamera.transform.localPosition.y) * 0.08f,0);
        } else
        {
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (0.8f-mainCamera.transform.localPosition.y) * 0.08f,0);
            sliding = false;
        }
    }
}
