using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public float deathHeight = -50;
    public GameObject image;

    public float deathDelayUntilRestart = 5;

    public AudioController audioController;

    bool dead = false;

    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathHeight && dead == false)
        {
            dead = true;
            image.GetComponent<Animator>().enabled = true;
            StartCoroutine(loadMenu());
        }
    }
    IEnumerator loadMenu()
    {
        float elapsedTime = 0;
        audioController.playDieSound();
        while(elapsedTime < deathDelayUntilRestart)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("DeathScreen");
    }
}
