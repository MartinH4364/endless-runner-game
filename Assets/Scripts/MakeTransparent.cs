using System.Collections;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    float duration = 0.5f;

    public IEnumerator makeTransparent()
    {
        foreach(Transform childTransform in transform)
        {
            if(childTransform.gameObject.GetComponent<BoxCollider>() != null)
            {
                Destroy(childTransform.gameObject.GetComponent<BoxCollider>());
            }
            if(childTransform.gameObject.GetComponent<MeshCollider>() != null)
            {
                Destroy(childTransform.gameObject.GetComponent<MeshCollider>());
            }
        }

        float elapsedTime = 0;
        float previousScale = 1;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            foreach(Transform childTransform in transform)
            {
                childTransform.localScale *= (duration-elapsedTime)/duration / previousScale;
            }

            previousScale = (duration-elapsedTime)/duration;
            yield return null;
        }

        Destroy(gameObject);
    }
}
