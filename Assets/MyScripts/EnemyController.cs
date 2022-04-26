using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float radius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public int health = 10;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = PlayerManager.instance.player.transform;
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Update()
    {
        if(target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= radius)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    FacePlayer();
                    Debug.Log("Health");
                    Attacking(1);
                    //attack 
                }
                else
                {

                }
            }
        }
        
    }

    public void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation= Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*2f); 
    }
    public void Attacking(int tempHealth)
    {
        health=health-tempHealth;
        Debug.Log(health);
        if(health<=0 && target!=null)
        {
            Destroy(target.gameObject);
        }
    }
}
