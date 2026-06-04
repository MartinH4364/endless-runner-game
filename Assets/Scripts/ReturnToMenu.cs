using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
