using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateRooms : MonoBehaviour
{
    public List<GameObject> rooms;
    public List<GameObject> brokenRooms;

    public GameObject upgradeRoom;
    public GameObject player;
    public int spawnDistance = 100;
    public int roomsPerUpgradeRoom = 50;

    public static bool inUpgradeRoom = false;

    int roomsSpawned = 0;
    int nextUpgradeRoom;

    void Start()
    {
        nextUpgradeRoom = roomsPerUpgradeRoom;
        inUpgradeRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        while(player.transform.position.z >= transform.position.z - spawnDistance && !inUpgradeRoom)
        {
            spawnRoom();
        }
    }

    void spawnRoom()
    {
        transform.position = new Vector3(0, 0,transform.position.z + 40);

        float brokenRoomChance = 0;
        if(UpgradeCalculator.TotalUpgrades >= 2)
        {
            brokenRoomChance = 0.1f;
        }else if(UpgradeCalculator.TotalUpgrades >= 5)
        {
            brokenRoomChance = 0.3f;
        }

        if(roomsSpawned != nextUpgradeRoom - 1){
            if(Random.Range(0f,1f) < brokenRoomChance)
            {
                generateBrokenRoom();
            }else{
                generateRoom();
            }
        }
        else
        {
            generateUpgradeRoom();
        }
        roomsSpawned += 1;
    }

    void generateRoom()
    {
        Instantiate(rooms[Random.Range(0,rooms.Count)],transform.position,Quaternion.identity);
    }

    void generateBrokenRoom()
    {
        Instantiate(brokenRooms[Random.Range(0,brokenRooms.Count)],transform.position,Quaternion.identity);        
    }

    void generateUpgradeRoom()
    {
        Instantiate(upgradeRoom,transform.position,Quaternion.identity);
        nextUpgradeRoom += roomsPerUpgradeRoom;
        inUpgradeRoom = true;
    }
}
