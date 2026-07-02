using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float scoreDistance = 10;
    public static int score = 0;
    public GameObject player;
    float farthestDistance;
    public TextMeshProUGUI text;

    void Start()
    {
        score = 0;
        farthestDistance = scoreDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z >= farthestDistance)
        {
            farthestDistance += scoreDistance;
            score += 1;
            text.text = score.ToString();
        }
    }
}
