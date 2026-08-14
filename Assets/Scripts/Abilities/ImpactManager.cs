using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public float chargeTime = 9;
    float charge = 0;
    UnityEngine.UI.Image chargeMeter;

    PlayerMovement playerMovement;

    public bool onRight = false;

    bool pressable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeMeter = GetComponent<UnityEngine.UI.Image>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        charge = chargeTime;
        if (onRight)
        {
            chargeMeter.fillClockwise = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(charge < chargeTime)
        {
            charge += Time.deltaTime;
        }
        else
        {
            charge = chargeTime;
        }

        if ((Input.GetKey(KeyCode.Q) && !onRight || Input.GetKey(KeyCode.E) && onRight)&& charge >= chargeTime/3 && pressable)
        {
            playerMovement.Impact();
            charge -= chargeTime/3;
            pressable = false;
        }
        if(!(Input.GetKey(KeyCode.Q) && !onRight || Input.GetKey(KeyCode.E) && onRight))
        {
            pressable = true;
        }

        chargeMeter.fillAmount = charge/chargeTime/2;
    }
}
