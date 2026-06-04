using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image image;
    public float fadeTime = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        float elapsedTime = fadeTime;
        while(elapsedTime > 0)
        {
            Color color = image.color;
            color.a = elapsedTime/fadeTime;
            elapsedTime -= Time.deltaTime;
            image.color = color;
            yield return null;
        }
        image.enabled = false;
    }
}
