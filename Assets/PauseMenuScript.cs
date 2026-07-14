using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject playerUI, mobileControlsUI, pauseMenu;
    public bool gamePaused;

    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            PauseGame();
            gamePaused = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            ResumeGame();
            gamePaused = false;
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None ;
        Time.timeScale = 0f;
        playerUI.SetActive(false);
        mobileControlsUI.SetActive(false);
        pauseMenu.SetActive(true);
        gamePaused = true;

    }
    public void ResumeGame()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        playerUI.SetActive(true);
        mobileControlsUI.SetActive(true);
        pauseMenu.SetActive(false);
        gamePaused = false;

    }
}
