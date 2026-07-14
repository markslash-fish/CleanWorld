using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
public class QueryManager : MonoBehaviour
{
    public GameObject queryBox;
    public TMP_Text question, choice1, choice2, choice3;
    public float combatTimer;
    public EcoTriviaQueryData ecotrivia;
    public PlayerMovement playermovement;
    public PlayerCameraMovement pcm;
    public TrashMonsterMechanics trashMonsterMechanics;
    public TrashMonsterMovement trashMonsterMovement;
    public TrashMonsterData TMData;
    public TrashcanScript trashcanScript;
    public PauseMenuScript pauseMenuScript;

    
    private void Start()
    {
        combatTimer = 5f;
        queryBox.SetActive(false);
       
    }
    private void Update()
    {
      
        
       
    }
    public void InitiateCombat()
    {
        queryBox.SetActive(true);
        question.SetText(ecotrivia.queryText);
        choice1.SetText(ecotrivia.choice1);
        choice2.SetText(ecotrivia.choice2);
        choice3.SetText(ecotrivia.correctAnswer);
        playermovement.enabled = false;
        pcm.camEnabled = false;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(CombatTimerElapsed());
        trashcanScript.trashcanCapBar.SetActive(false);
        pauseMenuScript.enabled = false;
       
       
       
       
       


    }
    public void CombatFinished()
    {
        
        queryBox.SetActive(false);

        playermovement.enabled = true;
        pcm.camEnabled = true;
        pauseMenuScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        
        
       

    }

    IEnumerator CombatTimerElapsed()
    {
        combatTimer = 5f;


        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(combatTimer);
        Time.timeScale = 1f;
        CombatFinished();
    }
}
