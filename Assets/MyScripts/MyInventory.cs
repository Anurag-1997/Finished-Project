using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public static MyInventory instance;
    public int inputMaxValue = 10;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Add(InventoryItem item)
    {
        if(!item.isDefaultItem)
        {
            if (inventoryItems.Count >= inputMaxValue)
            {
                Debug.Log("No enough space");
                return false;
            }
            inventoryItems.Add(item);

        }
        return true;


    }
    public void Remove(InventoryItem item)
    {
        inventoryItems.Remove(item); 
    }
}
