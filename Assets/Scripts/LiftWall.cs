using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftWall : MonoBehaviour
{
    float wallLiftSpeed = 160;

    IEnumerator liftWall()
    {
        float elapsedTime = 0;
        while(elapsedTime <= 0.5)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0;
        while(elapsedTime <= 20 / wallLiftSpeed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + wallLiftSpeed * Time.deltaTime, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public void publicLiftWall()
    {
        destroyUpgrades();
        StartCoroutine(liftWall());
    }

    void destroyUpgrades()
    {
        Array upgradeList = GameObject.FindGameObjectsWithTag("Upgrade");
        foreach(GameObject upgrade in upgradeList)
        {
            UpgradeManager script = upgrade.GetComponent<UpgradeManager>();
            script.StartCoroutine(script.destroyUpgrade());
        }
    }
}
