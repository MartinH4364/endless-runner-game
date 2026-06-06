using UnityEngine;

public class MakeRoomSafe : MonoBehaviour
{
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z - 40 <= player.transform.position.z && transform.position.z >= player.transform.position.z)
        {
            MoveDeathEmpty.inSafeRoom = true;
        }
        else
        {
            MoveDeathEmpty.inSafeRoom = false;
        }
    }
}
