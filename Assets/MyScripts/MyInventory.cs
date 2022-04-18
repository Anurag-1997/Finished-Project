using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add(InventoryItem item)
    {
        inventoryItems.Add(item);
    }
    //public void Remove
}
