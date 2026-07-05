using UnityEngine;

public class WalkAudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.walking && playerMovement.isGrounded)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } else
        {
            audioSource.Stop();
        }

        if (playerMovement.sprinting)
        {
            audioSource.pitch = 1.5f;
        } else
        {
            audioSource.pitch = 1;
        }
    }
}
