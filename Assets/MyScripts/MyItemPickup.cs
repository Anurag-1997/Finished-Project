using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItemPickup : MyInteractable
{
    public override void MyInteracted()
    {
        base.MyInteracted();
        PickUpObject();
    }

    private void PickUpObject()
    {
        Debug.Log("This is picking up object");
        Destroy(gameObject);
    }
}
