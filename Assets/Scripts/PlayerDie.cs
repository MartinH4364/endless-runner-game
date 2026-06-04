using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public float deathHeight = -50;
    public GameObject image;

    public float deathDelayUntilRestart = 5;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathHeight)
        {
            image.GetComponent<Animator>().enabled = true;
            StartCoroutine(loadMenu());
        }
    }
    IEnumerator loadMenu()
    {
        float elapsedTime = 0;
        while(elapsedTime < deathDelayUntilRestart)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("DeathScreen");
    }
}
