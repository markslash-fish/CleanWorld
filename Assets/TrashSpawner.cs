using System.CodeDom.Compiler;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public  GameObject trashPrefab;
    public GameObject spawner;
    public float spawnlimit = 2f;

  


    private void Start()
    {

        if (DifficultyManager.Instance != null)
        {
            var diffman = DifficultyManager.Instance;
            spawnlimit = diffman.trashSpawnLimit;

        }
        else
        {
            Debug.LogWarning("DifficultyManager instance not found. Using default spawn limit.");
            spawnlimit = 18;
        }
        StartupSpawn();

    }
    void StartupSpawn()
    {
        Renderer rend = GetComponent<Renderer>();
        MeshRenderer mrenderer = spawner.GetComponent<MeshRenderer>();
        Vector3 size = mrenderer.bounds.size;
        Vector3 center = mrenderer.bounds.center;

        for (int i = 0; i < spawnlimit; i++)
        {
            float randomX = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
            float randomZ = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);
            float yPos = spawner.transform.position.y + 1f;

            Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);

            Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
        }
        
    }
   
     
}
