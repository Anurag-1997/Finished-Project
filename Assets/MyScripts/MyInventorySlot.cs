using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInventorySlot : MonoBehaviour
{
    InventoryItem inventoryItem;
    public Image iconImage;
    
    public Button closeButton;
    public Image closeButtonImage;
    

    public void AddInventoryItem(InventoryItem newInventoryItem)
    {
        inventoryItem = newInventoryItem;
        iconImage.sprite = inventoryItem.icon;
        iconImage.enabled = true;
        closeButtonImage.enabled = true;
        closeButton.enabled = true;
        closeButton.interactable= true;

    }
    public void ClearSlotItem()
    {
        inventoryItem = null;
        iconImage.sprite = null;
        iconImage.enabled=false;
        closeButtonImage.enabled=false;
        closeButton.enabled=false;
        closeButton.interactable= false;
    }
    public void OnCloseButton()
    {
        MyInventory.instance.Remove(inventoryItem);
    }
    public void OnUseItem()
    {
        if(inventoryItem != null)
        {
            inventoryItem.UseItem();
        }
    }
}
