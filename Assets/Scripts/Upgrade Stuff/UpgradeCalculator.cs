using UnityEngine;

public class UpgradeCalculator : MonoBehaviour
{
    public static int Jump = 0;
    public static int Speed = 0;
    public static int Sprint = 0;
    public static int Stamina = 0;
    public static int SlowDestruction = 0;
    public static int SlideSlam = 0;
    public static int WallJumps = 0;
    public static int AirJumps = 0;

    public static int TotalUpgrades = 0;

    float baseJump = 0;
    float baseSpeed = 0;
    float baseSprint = 0;
    float baseStamina = 0;
    float baseDeathSpeed = 0;

    public PlayerMovement playerMovement;
    public GameObject deathEmpty;
    MoveDeathEmpty moveDeathEmpty;

    void Start()
    {
        baseJump = playerMovement.jumpHeight;
        baseSpeed = playerMovement.speed;
        baseSprint = playerMovement.sprintMultiplier;
        baseStamina = playerMovement.staminaRegenRate;

        moveDeathEmpty = deathEmpty.GetComponent<MoveDeathEmpty>();
        baseDeathSpeed = moveDeathEmpty.baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.jumpHeight = baseJump * (1 + Jump * 0.25f);
        playerMovement.speed = baseSpeed * (1 + Speed * 0.15f);
        playerMovement.sprintMultiplier = baseSprint * (1 + Sprint * 0.25f);
        playerMovement.staminaRegenRate = baseStamina * (1 + Stamina * 0.25f);
        moveDeathEmpty.baseSpeed = baseDeathSpeed * Mathf.Pow(0.9f, SlowDestruction);
        playerMovement.slideSlam = SlideSlam;
        playerMovement.maxAirJumps = AirJumps;
        playerMovement.wallJump = WallJumps;
    }
}
