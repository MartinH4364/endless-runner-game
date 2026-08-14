using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time;

    float elapsedTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime >= time)
        {
            Destroy(gameObject);
        } else
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
