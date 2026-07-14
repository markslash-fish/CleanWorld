using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarryLimitUI : MonoBehaviour
{
    public TrashcanScript trashcanScript;
    public GameObject carryLimitUI, carryLimitNotice;
    public TMP_Text trashHeld, carryLimitNoticeText;
    public Interaction interaction;

    void Start()
    {
        carryLimitNotice.SetActive(false);
        carryLimitUI.SetActive(true);
        carryLimitNoticeText.SetText("You Cannot Carry items More than <color=Red>" + interaction.maxTrashHeld + "</color> on your hand");
    }

    void Update()
    {
        SetTrashHeldText();
        SetCarryLimitNoticeText();
    }
    public void SetTrashHeldText()
    {
        trashHeld.SetText("Carry Limit: " + interaction.currentTrashHeld.ToString("0") + (" / ") + interaction.maxTrashHeld.ToString("0"));
        if (interaction.currentTrashHeld >= interaction.maxTrashHeld)
        {
            trashHeld.SetText("Carry Limit:  <color=Red>" + interaction.currentTrashHeld.ToString("0") + (" / ") + interaction.maxTrashHeld.ToString("0 </color>"));
        }
    }
    public void SetCarryLimitNoticeText()
    {
         if(trashcanScript.trashcanCurrentCap >= trashcanScript.trashcanMaxCap)
        {
            carryLimitNoticeText.SetText("The trashcan is already full! You cannot dispose trash anymore.");
            
        }
       


    }
}
