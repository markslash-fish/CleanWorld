using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string TrashTag = "Interactable";
    public string MonsterTag = "Monster";
    public string TrashcanTag = "Trashcan";
    private Collider currentTrashTarget = null;
    public Collider currentMonsterTarget = null, currentTrashcanTarget = null;
    public QueryManager qm;
    public TrashMonsterMechanics trashMonsterMechanics;
    public CarryLimitUI carryLimitUI;
    public TrashcanScript trashcanScript;
    public PlayerCameraMovement playerCameraMovement;
    public CompletionOverview completionOverview;
    public GameObject pickUpButton, disposeButton, interactButton, pauseButton, playerUI, mobileControlsUI, pauseMenu, resumeButton;
    
   

    [Header("Statistics")]
    public float trashdisposed, monstersDefeated;

    [Header("Carry Limit")]
    public float currentTrashHeld = 0f;
    public float maxTrashHeld = 5f;

    private void Start()
    {
        interactButton.SetActive(false);
        disposeButton.SetActive(false);
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
        mobileControlsUI.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TrashTag))
        {
            currentTrashTarget = other;
            Debug.Log("An Object is ready to be Extracted");
        }
        else if (other.CompareTag(MonsterTag))
        {
            currentMonsterTarget = other;
            Debug.Log("A Monster is nearby! Eliminate it!");

        }
        if (other.CompareTag(TrashcanTag))
        {
            currentTrashcanTarget = other;
            Debug.Log("Trashcan Detected. Put trash here");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == currentTrashTarget)
        {
            currentTrashTarget = null;
        }
        if (other == currentMonsterTarget)
        {
            currentMonsterTarget = null;
            interactButton.SetActive(false);
        }
        if (other == currentTrashcanTarget)
        {
            currentTrashcanTarget = null;
            disposeButton.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerTrashInteraction();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerTrashcanInteraction();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerMonsterInteraction();
        }
      

        ShowButton();
        


    }
    public void PlayerTrashInteraction()
    {


        if (currentTrashTarget != null)
        {
            if (currentTrashHeld >= maxTrashHeld)
            {
                Debug.Log("Cannot carry more items more than " + maxTrashHeld);
                carryLimitUI.carryLimitNotice.SetActive(true);
                StartCoroutine(CarryLimitNoticeTimer());
                return;


            }


            Destroy(currentTrashTarget.gameObject);
            currentTrashTarget = null;
            Debug.Log("An Object is extracted");
            currentTrashHeld++;
            currentTrashTarget = null;
        }






    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected: " + collision.gameObject.name);
    }
    public void PlayerMonsterInteraction()
    {

        if (currentMonsterTarget != null)
        {
            qm.InitiateCombat();

        }




    }
    public void PlayerTrashcanInteraction()
    {

        if (currentTrashcanTarget != null)
        {
            if (currentTrashHeld <= 0)
            {

                return;
            }
            else if (trashcanScript.trashcanCurrentCap >= trashcanScript.trashcanMaxCap)
            {

                StartCoroutine(CarryLimitNoticeTimer());
                completionOverview.StageCompleted();
                completionOverview.SetLoseText();
                Time.timeScale = 0f;
                return;

            }
            trashcanScript.trashcanCurrentCap++;
            currentTrashHeld--;
            trashdisposed++;
           

        }

    }
    public void MonsterOnDeath()
    {
        monstersDefeated++;
        Destroy(currentMonsterTarget.gameObject);
        Time.timeScale = 1f;
        currentMonsterTarget = null;
        interactButton.SetActive(false);
        qm.CombatFinished();
    }
    IEnumerator CarryLimitNoticeTimer()
    {
        carryLimitUI.carryLimitNotice.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        carryLimitUI.carryLimitNotice.SetActive(false);
    }

    public void ShowButton()
    {
        if (currentMonsterTarget != null)
        {
            interactButton.SetActive(true);
        }

        else if (currentTrashcanTarget != null)
        {
            disposeButton.SetActive(true);
        }
    }
   
    
}