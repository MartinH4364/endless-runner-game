using System.Collections;
using UnityEngine;

public class LiftWall : MonoBehaviour
{
    float wallLiftSpeed = 160;

    IEnumerator liftWall()
    {
        float elapsedTime = 0;
        while(elapsedTime <= 20 / wallLiftSpeed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + wallLiftSpeed * Time.deltaTime, transform.position.z);
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public void publicLiftWall()
    {
        StartCoroutine(liftWall());
    }
}
