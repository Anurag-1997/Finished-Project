using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MyPlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(this.target.position);
            FaceTarget();
        }
    }
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void MyTargetFollow(MyInteractable myNewTarget)
    {
        target = myNewTarget.transform;
        agent.stoppingDistance = myNewTarget.radius;
        agent.updateRotation = false;
    }
    public void MyTargetStopFollow()
    {
        target = null;
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
    }
    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion myRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, Time.deltaTime * 5f);
        
    }
}
