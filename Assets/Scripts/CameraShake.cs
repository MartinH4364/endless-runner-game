using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 1f;
    public float magnitude = 0.5f;
    public int pause = 4;
    
    public IEnumerator Shake(float duration, float magnitude, int pause)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;
        int framesPassed = 0;
        while(elapsed < duration){
            if(framesPassed == 0){
                framesPassed = pause + 1;

                float x = Random.Range(-1f,1f) * magnitude;
                float y = Random.Range(-1f,1f) * magnitude;

                transform.localPosition = new Vector3(x+originalPosition.x, y+originalPosition.y, originalPosition.z);
            }
            framesPassed -= 1;

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
