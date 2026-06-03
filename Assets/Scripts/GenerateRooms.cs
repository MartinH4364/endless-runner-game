using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateRooms : MonoBehaviour
{
    public List<GameObject> rooms;
    public GameObject player;
    public int spawnDistance = 100;
    // Update is called once per frame
    void Update()
    {
        while(player.transform.position.z >= transform.position.z - spawnDistance)
        {
            spawnRoom();
        }
    }

    void spawnRoom()
    {
        transform.position = new Vector3(0, 0,transform.position.z + 40);
        Instantiate(rooms[Random.Range(0,rooms.Count)],transform.position,Quaternion.identity);
    }
}
