using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CompletionOverview : MonoBehaviour
{
    public TMP_Text trashDisposed, trashMonstersDefeated, completionText, ScoreText;
    public Interaction interaction;
    public GameObject completionScreen, pauseMenu, mobileControlsUI, carryLimitUI;
    public TrashMonsterSpawner tms;
    public PlayerMovement playerMovement;
    public PlayerCameraMovement playerCameraMovement;
    public PauseMenuScript pauseMenuScript;
    public TrashcanScript trashcanScript;
    public AchievementsScript achievementsScript;
    public DifficultyManager difficultyManager;
    public float score;
    public bool stageCleared;
    public string easy, medium, hard;
    private void Start()
    {
       

        completionScreen.SetActive(false);
        if(stageCleared)
        {
          
                achievementsScript.achievement3 = true;
           
        }
        if(AchievementsScript.achievements != null)
        {
            achievementsScript = AchievementsScript.achievements;
           
        }
        if(DifficultyManager.Instance != null)
        {
            difficultyManager = DifficultyManager.Instance;
        }
    }
    void Update()

    {
        if(stageCleared)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
       
            score = (interaction.trashdisposed * 10) + (interaction.monstersDefeated * 25);

        if (tms.trashcount == 0 && tms.currentMonsterCount == 0 && tms.finalWaveSpawned && interaction.currentTrashHeld == 0 && !stageCleared)

        {
            if(difficultyManager.easy)
            {
                achievementsScript.achievement2 = true;
            }
            else if(difficultyManager.medium)
            {
                achievementsScript.achievement3 = true;
            }
            else if (difficultyManager.hard)
            {
                achievementsScript.achievement4 = true;
            }
            StageCompleted();
           

        }
    }
    public void StageCompleted()
    {

        Cursor.lockState = CursorLockMode.None;
        completionScreen.SetActive(true);
        pauseMenu.SetActive(false);
        carryLimitUI.SetActive(false);
        mobileControlsUI.SetActive(false);
        trashDisposed.SetText("Trash Disposed: " + interaction.trashdisposed);
        trashMonstersDefeated.SetText("Trash Monsters Defeated: " + interaction.monstersDefeated);
        ScoreText.SetText("Score: " + score);
       

        pauseMenuScript.enabled = false;
        trashcanScript.trashcanCapBar.SetActive(false);
        stageCleared = true;
       


    }


    public void PlayAgain()
    {
         
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
        stageCleared = false;

    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        stageCleared = false;
    }
    public void SetLoseText()
    {
        completionText.SetText("<color=Red> Area not Cleared! </color>");
    }
}
