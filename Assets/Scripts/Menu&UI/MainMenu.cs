using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject OptionMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        Main.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void Back(){
        Main.SetActive(true);
        OptionMenu.SetActive(false);
    }
}
