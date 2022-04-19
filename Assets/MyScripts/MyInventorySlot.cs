using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInventorySlot : MonoBehaviour
{
    InventoryItem inventoryItem;
    public Image iconImage;
    

    public void AddInventoryItem(InventoryItem newInventoryItem)
    {
        inventoryItem = newInventoryItem;
        iconImage.sprite = inventoryItem.icon;
        iconImage.enabled = true;
    }
    public void ClearSlotItem()
    {
        inventoryItem = null;
        iconImage.sprite = null;
        iconImage.enabled=false;
    }
}
