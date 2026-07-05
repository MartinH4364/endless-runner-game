using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class StaminaOrbManager : MonoBehaviour
{
    public float staminaRegenAmount = 50;
    public float spawnChance = 0.1f;

    public AudioSource humSound;
    public AudioClip collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(PlayerMovement.stamina + staminaRegenAmount <= 100)
            {
                PlayerMovement.stamina += staminaRegenAmount;
            } else
            {
                PlayerMovement.stamina = 100;
            }

            humSound.Stop();
            Camera.main.GetComponentInParent<AudioSource>().PlayOneShot(collectSound);

            Destroy(gameObject);
        }
    }

    void Spawn()
    {
        if(Random.Range(0f,1.0f) > spawnChance)
        {
            Destroy(gameObject);
        }
    }
}
