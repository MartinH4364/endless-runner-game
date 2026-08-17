using UnityEngine;

public class TeleportManager : MonoBehaviour
{

    public float chargeTime = 10;
    float charge = 0;
    UnityEngine.UI.Image chargeMeter;

    PlayerMovement playerMovement;

    public GameObject teleportEffects;

    public bool onRight = false;

    public float throwPower = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeMeter = GetComponent<UnityEngine.UI.Image>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        charge = chargeTime;
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

        if ((Input.GetKey(KeyCode.Q) && !onRight || Input.GetKey(KeyCode.E) && onRight)&& charge == chargeTime)
        {
            GameObject teleportObject = Instantiate(teleportEffects, transform.parent.parent);
            TeleportController teleportController = teleportObject.GetComponent<TeleportController>();

            teleportObject.transform.SetParent(null);

            teleportController.velocity = playerMovement.velocity;
            teleportController.velocity.z += Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(Camera.main.transform.eulerAngles.x * Mathf.Deg2Rad) * throwPower;
            teleportController.velocity.x += Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(Camera.main.transform.eulerAngles.x * Mathf.Deg2Rad) *  throwPower;
            teleportController.velocity.y += -Mathf.Sin(Camera.main.transform.eulerAngles.x * Mathf.Deg2Rad) * throwPower;

            charge = 0;
        }

        chargeMeter.fillAmount = charge/chargeTime/2;
        
        if (chargeMeter.fillClockwise)
        {
            onRight = false;
        } else
        {
            onRight = true;
        }
    }
}
