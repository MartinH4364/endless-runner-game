using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateRooms : MonoBehaviour
{
    public List<GameObject> rooms;
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

        if(roomsSpawned != nextUpgradeRoom - 1){
            Instantiate(rooms[Random.Range(0,rooms.Count)],transform.position,Quaternion.identity);
        }
        else
        {
            Instantiate(upgradeRoom,transform.position,Quaternion.identity);
            nextUpgradeRoom += roomsPerUpgradeRoom;
            inUpgradeRoom = true;
        }
        roomsSpawned += 1;
    }
}
