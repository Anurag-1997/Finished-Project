using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyCharacterAnimController : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponentInChildren<Animator>(); 
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("playerSpeed", playerSpeed, 0.1f, Time.deltaTime);
    }
}
