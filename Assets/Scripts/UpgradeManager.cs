using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class UpgradeManager : MonoBehaviour
{
    float destroyTime = 0.25f;
    Vector3 startPos;
    bool selected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected)
        {
            transform.position = startPos;
        } else if (selected)
        {
            transform.position = new Vector3(startPos.x, startPos.y, startPos.z - 1f);
        }
    }

    public IEnumerator destroyUpgrade()
    {
        if (selected)
        {
            string name = gameObject.name.Replace("(Clone)", "");
            if(name == "JumpUpgrade")
            {
                UpgradeCalculator.Jump += 1;
            }
            if(name == "SpeedUpgrade")
            {
                UpgradeCalculator.Speed += 1;
            }
            if(name == "SprintUpgrade")
            {
                UpgradeCalculator.Sprint += 1;
            }
            if(name == "StaminaUpgrade")
            {
                UpgradeCalculator.Stamina += 1;
            }
        }

        float moveDist = startPos.z - transform.position.z + 1;
        float elapsedTime = 0;
        while(elapsedTime < destroyTime)
        {
            transform.position += Vector3.forward * moveDist * Time.deltaTime / destroyTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    
    public void onClick()
    {
        GameObject upgradeWall = transform.parent.gameObject;
        upgradeWall.GetComponent<UpgradeController>().selectNewUpgrade();
        selected = true;
    }

    public void deselectUpgrade()
    {
        selected = false;
    }
}
