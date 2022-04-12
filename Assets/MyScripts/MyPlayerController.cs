using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
	Camera cam;
	public LayerMask movementMask;
	MyPlayerMovement myPlayerMov;
	// Start is called before the first frame update
	void Start()
    {
		cam = Camera.main;
		myPlayerMov = GetComponent<MyPlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))//This area to make player move
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
			}
		}

	}
}
