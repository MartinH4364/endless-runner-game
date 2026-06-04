using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public float deathHeight = -50;
    public GameObject image;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathHeight)
        {
            image.GetComponent<Animator>().enabled = true;
        }
    }
}
