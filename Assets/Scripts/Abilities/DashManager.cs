using UnityEngine;

public class DashManager : MonoBehaviour
{
    public float chargeTime = 5;
    float charge = 0;
    UnityEngine.UI.Image chargeMeter;

    PlayerMovement playerMovement;

    AudioSource audioSource;

    public AudioClip dashSound;
    
    public bool onRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeMeter = GetComponent<UnityEngine.UI.Image>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
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
            playerMovement.Dash();
            audioSource.PlayOneShot(dashSound);
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
