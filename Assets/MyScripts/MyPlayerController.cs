using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyPlayerController : MonoBehaviour
{
	Camera cam;
	public LayerMask movementMask;
	MyPlayerMovement myPlayerMov;
	public MyInteractable myIntFocus;
	


	// Start is called before the first frame update
	void Start()
    {
		cam = Camera.main;
		myPlayerMov = GetComponent<MyPlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
		if(EventSystem.current.IsPointerOverGameObject())
        {
			Debug.Log("Clicking on UI");

			return;
        }
		if (Input.GetMouseButtonDown(1))//This area to make player move
		{
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			if (Physics.Raycast(ray, out hit,100f,movementMask))
			{
				//To move our player to what we hit
				Debug.Log("The object name" + hit.collider.name + " " + hit.point);
				myPlayerMov.MoveToPoint(hit.point);
				//stop the focus
				StopFocus();

				
			}
		}
		if (Input.GetMouseButtonDown(0))//This area to make player move
		{
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			if (Physics.Raycast(ray, out hit, 100f))
			{
				//check player can interact with enemy or not
				Debug.Log("interactable object");
				MyInteractable myInt = hit.collider.GetComponent<MyInteractable>();
				if(myInt != null)
                {
					SetFocus(myInt);
                }
			}
			
		}

	}

    private void SetFocus(MyInteractable myIntereactable)
    {
		
		
		//myPlayerMov.MoveToPoint(myIntereactable.transform.position);
		if(myIntereactable!=myIntFocus)
        {
			if(myIntFocus!=null)
            {
				myIntFocus.StopFocused();
			}
			myIntFocus = myIntereactable;
			myPlayerMov.MyTargetFollow(myIntereactable);
		}
		myIntereactable.OnFocused(transform);
	}
	void StopFocus()
    {
		
		if(myIntFocus != null)
        {
			myIntFocus.StopFocused();
		}
		myIntFocus = null;
		myPlayerMov.MyTargetStopFollow();


	}
}
