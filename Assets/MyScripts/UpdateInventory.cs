using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateInventory : MonoBehaviour
{
    public MyInventory inventory;
    public Transform itemsPanel;
    MyInventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = MyInventory.instance;
        inventory.onItemChanged += UpdateUserInterface;
        slots=itemsPanel.GetComponentsInChildren<MyInventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUserInterface()
    {
        Debug.Log("Update UI");
        for(int i = 0; i < slots.Length; i++)
        {
            if(i<inventory.inventoryItems.Count)
            {
                slots[i].AddInventoryItem(inventory.inventoryItems[i]);
            }
            else
            {
                slots[i].ClearSlotItem();
            }
        }


    }
}
