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
    public bool isGrounded;

    public static float stamina = 100;
    public float staminaRegenRate = 2;
    float speedMultiplier = 1;

    public float airDrag = 0.9f;
    public float slideDrag = 0.995f;
    public float groundDrag = 0.9f;

    bool previousGrounded = true;
    bool canJump = true;

    public float sprintStaminaDrain = 5;
    public float sprintMultiplier = 2;
    public bool sprinting = false;
    bool sliding = false;

    public bool walking = false;

    public float dashPower = 20f;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        handleSlide();

        handleDrag();

        handleJump();

        handleSprint();

        handleWalk();

        handleStamina();

        handleAbilities();

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

        if(Horizontal == 0 && Vertical == 0 || sliding)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }

        if(!sliding){
            if(isGrounded)
            {
                velocity.z += Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * (speed * (1-groundDrag)) * speedMultiplier;
                velocity.x += Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * (speed * (1-groundDrag)) * speedMultiplier;
                velocity.z += Mathf.Sin(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * (speed * (1-groundDrag)) * speedMultiplier;
                velocity.x += Mathf.Cos(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * (speed * (1-groundDrag)) * speedMultiplier;
            } else
            {
                velocity.z += Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * (speed * (1-airDrag)) * speedMultiplier;
                velocity.x += Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Vertical * (speed * (1-airDrag)) * speedMultiplier;
                velocity.z += Mathf.Sin(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * (speed * (1-airDrag)) * speedMultiplier;
                velocity.x += Mathf.Cos(-mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Horizontal * (speed * (1-airDrag)) * speedMultiplier;
            }
        }
    }

    void handleDrag()
    {
        if(isGrounded){
            if (sliding)
            {
                velocity.z *= slideDrag;
                velocity.x *= slideDrag;
            }
            else
            {
                velocity.x *= groundDrag;
                velocity.z *= groundDrag;
            }
        } else
        {
            velocity.z *= airDrag;
            velocity.x *= airDrag;
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
        if (Input.GetKey(KeyCode.C) && isGrounded)
        {
            sliding = true;
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (1.0f-mainCamera.transform.localPosition.y) * 0.08f,0);
        } else
        {
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (1.6f-mainCamera.transform.localPosition.y) * 0.08f,0);
            sliding = false;
        }
    }

    void handleAbilities()
    {
        if(Input.GetKey(KeyCode.E) && isGrounded)
        {
            Dash();
        }
    }

    public void Dash()
    {
        velocity.z += Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) * dashPower;
        velocity.x += Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) *  dashPower;
        velocity.y += -Mathf.Sin(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) * dashPower;
    }
}