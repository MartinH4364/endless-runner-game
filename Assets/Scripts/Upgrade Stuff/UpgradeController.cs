using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public List<GameObject> Upgrades;
    public List<GameObject> SilverUpgrades;

    public float silverUpgradeChance = 0.25f;

    GameObject upgrade1;
    GameObject upgrade2;
    GameObject upgrade3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnUpgrades();
    }

    void spawnUpgrades()
    {
        if(Random.value <= silverUpgradeChance)
        {
            upgrade1 = Instantiate(SilverUpgrades[Random.Range(0,SilverUpgrades.Count)],transform.position+Vector3.left*12, Quaternion.identity);
        } else
        {
            upgrade1 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position+Vector3.left*12, Quaternion.identity);            
        }

        upgrade1.transform.parent = transform;

        if(Random.value <= silverUpgradeChance)
        {
            upgrade2 = Instantiate(SilverUpgrades[Random.Range(0,SilverUpgrades.Count)],transform.position, Quaternion.identity);
        } else
        {
            upgrade2 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position, Quaternion.identity);           
        }

        upgrade2.transform.parent = transform;

        if(Random.value <= silverUpgradeChance)
        {
            upgrade3 = Instantiate(SilverUpgrades[Random.Range(0,SilverUpgrades.Count)],transform.position+Vector3.right*12, Quaternion.identity);
        } else
        {
            upgrade3 = Instantiate(Upgrades[Random.Range(0,Upgrades.Count)],transform.position+Vector3.right*12, Quaternion.identity);            
        }

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
