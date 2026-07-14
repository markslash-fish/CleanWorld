using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;


public class TrashMonsterMechanics : MonoBehaviour, IDamageable
{

    TrashMonsterMovement tmm;
    public GameObject trash;
    public TrashMonsterData TMData;
    public QueryManager queryManager;
    public Interaction interaction;
    public DifficultyManager difficultyManager;
    public float monsterHp = 1f;
    private Coroutine spawningCoroutine;

    void Awake()
    {
        if(DifficultyManager.Instance != null)
        {
            difficultyManager = DifficultyManager.Instance;
        }
    }
    private void Start()
    {
        tmm = GetComponent<TrashMonsterMovement>();
        monsterHp = TMData.healthpoints;

    }
    private void Update()
    {
      
        MonsterTrashSpawning();
    }
    public void MonsterTrashSpawning()
    {
        if (!tmm.isMoving && spawningCoroutine == null)
        {
            spawningCoroutine = StartCoroutine(TrashSpawningLoop());
        }
        else if (tmm.isMoving && spawningCoroutine !=null)
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }
          
    }
    IEnumerator TrashSpawningLoop()
    {
        while (true)
        {
            float delays = Random.Range(difficultyManager.minTrashSpawn, difficultyManager.maxTrashSpawn);
            yield return new WaitForSeconds(delays);
            MeshRenderer mrenderer = GetComponent<MeshRenderer>();
            Vector3 size = mrenderer.bounds.size;
            Vector3 center = mrenderer.bounds.center;

            float randomX = Random.Range(center.x - size.x + 2f, center.x + size.x + 2f );
            float randomZ = Random.Range(center.z - size.z + 2f , center.z + size.z + 2f );
            float yPos = transform.position.y + 3f;


            Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);

            Instantiate(trash, spawnPosition, Quaternion.identity);
            Debug.Log("Monster spawned a trash!");
        }
    }

    public void TakeDamage(float amount)
    {
      
    }
  
   
}
