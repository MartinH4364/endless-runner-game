using UnityEngine;

public class UpgradeCalculator : MonoBehaviour
{
    public static int Jump = 0;
    public static int Speed = 0;
    public static int Sprint = 0;
    public static int Stamina = 0;

    public static int TotalUpgrades = 0;

    float baseJump = 0;
    float baseSpeed = 0;
    float baseSprint = 0;
    float baseStamina = 0;

    public PlayerMovement playerMovement;

    void Start()
    {
        baseJump = playerMovement.jumpHeight;
        baseSpeed = playerMovement.speed;
        baseSprint = playerMovement.sprintMultiplier;
        baseStamina = playerMovement.staminaRegenRate;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.jumpHeight = baseJump * (1 + Jump * 0.5f);
        playerMovement.speed = baseSpeed * (1 + Speed * 0.25f);
        playerMovement.sprintMultiplier = baseSprint * (1 + Sprint * 0.25f);
        playerMovement.staminaRegenRate = baseStamina * (1 + Stamina * 0.5f);

        TotalUpgrades = Speed + Sprint + Jump + Stamina;
    }
}
