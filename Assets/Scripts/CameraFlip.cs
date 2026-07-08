using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFlip : MonoBehaviour
{
    public void publicFlipCamera(float duration, int flipAmount)
    {
        StartCoroutine(flipCamera(duration, flipAmount));
    }

    IEnumerator flipCamera(float duration, int flipAmount)
    {
        float elapsedTime = 0;
        float startingY = Camera.main.transform.localEulerAngles.y;
        float startingX = Camera.main.transform.localEulerAngles.x;
        MouseLook mouseLook = Camera.main.GetComponent<MouseLook>();
        mouseLook.doingSomethingCool = true;
        Debug.Log(startingX);
        Debug.Log(startingY);

        while(elapsedTime <= duration*flipAmount)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(startingX + elapsedTime/duration*360,startingY,0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mouseLook.doingSomethingCool = false;
    }
}
