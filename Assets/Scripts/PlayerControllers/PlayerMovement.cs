using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

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

    public Transform wallCheck;
    public float wallDistance = 1.05f;

    Vector3 velocity;
    Vector3 velocityQueue;
    public bool isGrounded;
    public bool touchingWall;

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
    public float dashHorizontalMultiplier = 2;
    
    public float flipPower = 80f;

    public int maxAirJumps = 1;
    float airJumps;

    public int wallJump = 1;

    float slideSlam = 1;
    float prevYVel = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        touchingWall = Physics.CheckSphere(wallCheck.position, wallDistance, groundMask);

        handleJump();

        handleSlide();

        handleDrag();

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
                velocity.y = 0f;
            }

            if(Input.GetButton("Jump") && stamina >= jumpCost && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                stamina -= jumpCost;
                canJump = false;
            }

            airJumps = maxAirJumps;
        } else
        {   if(Input.GetButton("Jump") && stamina >= jumpCost * 1.5 && canJump && wallJump > 0 && touchingWall)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                stamina -= jumpCost * 1.5f;
                canJump = false;
            }
            else if(Input.GetButton("Jump") && stamina >= jumpCost && canJump && airJumps > 0)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                stamina -= jumpCost;
                canJump = false;
                airJumps -= 1;
            }
        }

        if (!Input.GetButton("Jump"))
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
            if(slideSlam > 0 && prevYVel < 0)
            {
                velocity.z += Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * -prevYVel;
                velocity.x += Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * -prevYVel;
            }
            sliding = true;
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (1.0f-mainCamera.transform.localPosition.y) * 0.08f,0);
        } else
        {
            mainCamera.transform.localPosition = new Vector3(0,mainCamera.transform.localPosition.y + (1.6f-mainCamera.transform.localPosition.y) * 0.08f,0);
            sliding = false;
        }

        if(slideSlam > 0)
        {
            if(Input.GetKey(KeyCode.C) && !isGrounded)
            {
                velocity.y += gravity / (15 / slideSlam);
            }
        }
        prevYVel = velocity.y;
    }

    void handleAbilities()
    {
        velocity += velocityQueue;
        velocityQueue = Vector3.zero;
    }

    public void Dash()
    {
        velocityQueue.z += dashHorizontalMultiplier * Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) * dashPower;
        velocityQueue.x += dashHorizontalMultiplier * Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) *  dashPower;
        velocityQueue.y += -Mathf.Sin(mainCamera.transform.eulerAngles.x * Mathf.Deg2Rad) * dashPower;
    }

    public void Flip()
    {
        velocityQueue.z += flipPower * Mathf.Cos(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad);
        velocityQueue.x += flipPower * Mathf.Sin(mainCamera.transform.eulerAngles.y * Mathf.Deg2Rad);
        if (isGrounded)
        {
            velocityQueue.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        }
    }
}