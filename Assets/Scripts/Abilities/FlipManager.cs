using UnityEngine;

public class FlipManager : MonoBehaviour
{
    public float chargeTime = 3;
    float charge = 0;

    UnityEngine.UI.Image chargeMeter;

    PlayerMovement playerMovement;

    public bool onRight = true;

    CameraFlip cameraFlip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeMeter = GetComponent<UnityEngine.UI.Image>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        charge = chargeTime;

        cameraFlip = Camera.main.GetComponent<CameraFlip>();
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
            cameraFlip.publicFlipCamera(0.4f,1);
            playerMovement.Flip();
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
