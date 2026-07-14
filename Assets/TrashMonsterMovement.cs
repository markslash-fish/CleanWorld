using System.Collections;
using UnityEngine;

public class TrashMonsterMovement : MonoBehaviour
{
    public TrashMonsterData TMData;
    public bool isMoving = false;
    public float patrolRadius = 0.1f;
    private Vector3 center;
    private float angle;
    public QueryManager queryManager;
    void Start()
    {
        center = transform.position;
        StartCoroutine(movementDelays());
    }
    private void Update()
    {
     
        MonsterPatrolling();
    }
    public void MonsterPatrolling()
    {
        if (isMoving)
        {
            angle += TMData.moveSpd * Time.deltaTime;

            float x = Mathf.Cos(angle) * patrolRadius;
            float z = Mathf.Sin(angle) * patrolRadius;

            transform.position = center + new Vector3(x, 0, z);
            transform.LookAt(center);
        }
       
          
    }
    IEnumerator movementDelays()
    {
        while(true)
        {
            isMoving = true;
            float delays = Random.Range(2f, 3.5f);
            yield return new WaitForSeconds(delays);

            isMoving = false;
            yield return new WaitForSeconds(delays);
        }
      
    }
  
}
