using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementsScript : MonoBehaviour
{
    public GameObject achievementPopupUI, a1entry, a2entry, a3entry, a4entry ;
    public TMP_Text achievementText;
    public bool a1, a2, a3, a4;
    public static AchievementsScript achievements;
    public bool achievementUnlocked;
    public bool achievement1, achievement2, achievement3, achievement4;
    void Start()
    {
        achievementPopupUI.SetActive(false);
       
    }

    private void Awake()
    {

        if (achievements == null)
        {

            achievements = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
     
     
        if (achievement1 && !a1)
        {
            achievementText.SetText("Play CleanWorld for the first time!");
            achievementUnlocked = true;
            achievement1 = false;
           
            a1 = true;
        }
        else if (achievement2 && !a2)
        {
            achievementText.SetText("Beat Easy Mode");
            achievementUnlocked = true;
            achievement2 = false;
           
            a2 = true;
        }
        else if (achievement3 && !a3)
        {
            achievementText.SetText("Beat Medium Mode");
            achievementUnlocked = true;
            achievement3 = false;
            
            a3 = true;
        }
        else if (achievement4 && !a4)
        {
            achievementText.SetText("Beat Hard Mode");
            achievementUnlocked = true;
            achievement4 = false;
            
            a4 = true;
        }
      

        AchievementUnlocked();
       
    }
    public void AchievementUnlocked()
    {
        if(achievementUnlocked)
        {
            
            StartCoroutine(AchievementUnlockedVisible());
            achievementUnlocked = false;
         
            
        }
    }
    IEnumerator AchievementUnlockedVisible()
    {
       
        achievementPopupUI.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        achievementPopupUI.SetActive(false);
    }

}
