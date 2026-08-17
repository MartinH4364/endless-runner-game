using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject OptionMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        UpgradeCalculator.Jump = 0;
        UpgradeCalculator.Speed = 0;
        UpgradeCalculator.Sprint = 0;
        UpgradeCalculator.Stamina = 0;
        UpgradeCalculator.SlowDestruction = 0;
        UpgradeCalculator.AirJumps = 0;
        UpgradeCalculator.SlideSlam = 0;
        UpgradeCalculator.WallJumps = 0;
        UpgradeCalculator.TotalUpgrades = 0;
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
