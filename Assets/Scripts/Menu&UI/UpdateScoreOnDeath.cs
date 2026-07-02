using TMPro;
using UnityEngine;

public class UpdateScoreOnDeath : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + ScoreManager.score;
        Cursor.lockState = CursorLockMode.None;
    }
}
