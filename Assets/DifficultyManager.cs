using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
    }
    public static DifficultyManager Instance;

    public int difficulty = 1;
    public Difficulty currentdiff;
    public float trashSpawnLimit;
    public float trashMonsterInitialSpawn;
    public float trashMonsterSpawnDelay;
    public float minTrashSpawn;
    public float maxTrashSpawn;
    public bool easy, medium, hard;

    private void Awake()

    {
        if (Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            DiffSelected(currentdiff);
    }
   
    public void DiffSelected(Difficulty diff)
    {
        currentdiff = diff;
        SetSpawnLimit();
        Debug.Log("Difficulty:" + diff + "Selected");
    }
    public void SetSpawnLimit()
    {
        switch (currentdiff)
        {
            case Difficulty.Easy:
                trashSpawnLimit = 12f;
                trashMonsterInitialSpawn = 1f;
                trashMonsterSpawnDelay = 60f;
                minTrashSpawn = 0.7f;
                maxTrashSpawn = 1.2f;
                easy = true;
                medium = false;
                hard = false;
                break;
               
            case Difficulty.Medium:
                trashSpawnLimit = 16f;
                trashMonsterInitialSpawn = 2f;
                trashMonsterSpawnDelay = 45f;
                minTrashSpawn = 0.5f;
                maxTrashSpawn = 1f;
                easy = false;
                medium = true;
                hard = false;

                break;

            case Difficulty.Hard:
                trashSpawnLimit = 28f;
                trashMonsterInitialSpawn = 3f;
                trashMonsterSpawnDelay = 30f;
                minTrashSpawn = 0.3f;
                maxTrashSpawn = 0.7f;
                easy = false;
                medium = false;
                hard = true;

                break;         
              
        }
    }
    
}


