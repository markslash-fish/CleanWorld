using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TrashMonsterSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject trashMonsterPrefab;
    public GameObject spawner;
    public float monsterInitialSpawnLimit;
    public float monsterSpawnDelay;
    public float trashcount = 2f;
    public float maxSpawnLimit = 7f;
    public float currentMonsterCount;
    public bool finalWaveSpawned;
    
    private void Awake()
    {
        var diffman = DifficultyManager.Instance;
        monsterInitialSpawnLimit = diffman.trashMonsterInitialSpawn;
        monsterSpawnDelay = diffman.trashMonsterSpawnDelay;
    }
    private void Update()
    {
        currentMonsterCount = GameObject.FindGameObjectsWithTag("Monster").Length;
         trashcount = GameObject.FindGameObjectsWithTag("Interactable").Length;
        monsterSpawnDelay = DifficultyManager.Instance.trashMonsterSpawnDelay;
        if (!finalWaveSpawned && trashcount <= 5) 
        {
            finalWaveSpawned = true;
            StartCoroutine(FinalWave());
         
               
            
            StartCoroutine(MonsterSpawnLoop());
        }
        if (currentMonsterCount == maxSpawnLimit)
        {
            StopCoroutine(MonsterSpawnLoop());
           
        }
    }
   
    IEnumerator MonsterSpawnLoop()
    {
        for (float i = currentMonsterCount; i < maxSpawnLimit; i++)
        {
            yield return new WaitForSeconds(monsterSpawnDelay);
            Debug.Log("Spawned after delay");
            MonsterSpawning();
        }
    }
    public void MonsterSpawning()
    {

        MeshRenderer renderer = spawner.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;
        Vector3 center = renderer.bounds.center;

        float randomX = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
        float randomZ = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);
        float yPos = spawner.transform.position.y + 0.5f;

        Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);
        Instantiate(trashMonsterPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Monster Spawned after delay");
       
    }
    IEnumerator FinalWave()
    {
        Debug.Log("Monsters will spawn in 5 seconds");
        yield return new WaitForSeconds(5f);
        MeshRenderer renderer = spawner.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;
        Vector3 center = renderer.bounds.center;

        for (int i = 0; i < monsterInitialSpawnLimit; i++)
        {
            float randomX = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
            float randomZ = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);
            float yPos = spawner.transform.position.y + 0.5f;

            Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);

            Instantiate(trashMonsterPrefab, spawnPosition, Quaternion.identity);
        }
        Debug.Log("The final wave of trash monsters have spawned");
    }
    
}
