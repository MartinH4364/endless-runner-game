using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip dieSound;

    public void playDieSound()
    {
        audiosource.PlayOneShot(dieSound);
    }
}
