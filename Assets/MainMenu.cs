using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject diffmenu;
    public GameObject achievementsmenu;
    public AchievementsScript achievementsScript;
    private void Start()
    {
        mainmenu.SetActive(true);
        diffmenu.SetActive(false);
        achievementsmenu.SetActive(false);

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Stage 1");
        

    }

    public void EasyDiff()
    {
        DifficultyManager.Instance.DiffSelected(DifficultyManager.Difficulty.Easy);
        PlayGame();
        achievementsScript.achievement1 = true;
    }
    public void MidDiff()
    {
        DifficultyManager.Instance.DiffSelected(DifficultyManager.Difficulty.Medium);
        PlayGame();
        achievementsScript.achievement1 = true;
    }
   public  void HardDiff()
    {
        DifficultyManager.Instance.DiffSelected(DifficultyManager.Difficulty.Hard);
        PlayGame();
        achievementsScript.achievement1 = true;
    }
  public   void QuitGame()
    {
        Application.Quit();
    }
  public void AchievementsButton()
    {
        mainmenu.SetActive(false);
        diffmenu.SetActive(false);
        achievementsmenu.SetActive(true);
    }
  public void BackButton()
    {
        mainmenu.SetActive(true);
        diffmenu.SetActive(false);
        achievementsmenu.SetActive(false);
    }
}