using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInteractable : MonoBehaviour
{
    public float radius;
    bool isFocus = false;
    public Transform player;
    bool hasInteracted = false;
    public Transform interactableObjectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocus && !hasInteracted) 
        {
            float distance = Vector3.Distance(player.position, interactableObjectTransform.position);
            if(distance <= radius)
            {
               
                MyInteracted();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(interactableObjectTransform==null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactableObjectTransform.position, radius);
        }
       

    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }
    public void StopFocused()
    {
        isFocus=false;
        player = null;
    }
    public virtual void MyInteracted()
    {
        //this method is overwritten again and again 
        Debug.Log("I am interacting  " + transform.name);
    }
}
