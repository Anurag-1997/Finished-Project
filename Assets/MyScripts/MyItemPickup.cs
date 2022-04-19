using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItemPickup : MyInteractable
{
    public InventoryItem inventoryItem;
    public override void MyInteracted()
    {
        base.MyInteracted();
        PickUpObject();
    }

    private void PickUpObject()
    {
        Debug.Log("This is picking up object" + inventoryItem.Name);
        bool wasPickedUp = MyInventory.instance.Add(inventoryItem);
       if (wasPickedUp)
       {
            Destroy(gameObject);
       }
        
    }
}
