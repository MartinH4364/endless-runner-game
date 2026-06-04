using UnityEngine;

public class MoveDeathEmpty : MonoBehaviour
{
    public GameObject player;
    public float baseSpeed = 5;
    public float distanceForSpeedIncrease = 25;
    bool activated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activated){
            transform.Translate(Vector3.forward * Time.deltaTime * (baseSpeed + ScoreManager.score/distanceForSpeedIncrease));
        } else
        {
            if(player.transform.position.z >= 20)
            {
                activated = true;
            }
        }
    }


}
