using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UpgradeController : MonoBehaviour
{
    public List<GameObject> Upgrades;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnUpgrades();
    }

    void spawnUpgrades()
    {
        GameObject upgrade1 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position+Vector3.left*12, Quaternion.identity);
        upgrade1.transform.parent = transform;
        GameObject upgrade2 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position, Quaternion.identity);
        upgrade2.transform.parent = transform;
        GameObject upgrade3 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position+Vector3.right*12, Quaternion.identity);
        upgrade3.transform.parent = transform;
    }

    public void selectNewUpgrade()
    {
        foreach(UpgradeManager upgradeManager in GetComponentsInChildren<UpgradeManager>())
        {
            upgradeManager.deselectUpgrade();
        }
    }
}
