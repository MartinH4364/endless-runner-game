using UnityEngine;

public class MoveDeathEmpty : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;
    bool activated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activated){
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        } else
        {
            if(player.transform.position.z >= 20)
            {
                activated = true;
            }
        }
    }


}
