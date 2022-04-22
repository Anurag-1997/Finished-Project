using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public MyEquipment[] currentEquipment;
    MyInventory inventory;
    public delegate void OnEquipmentChanged(MyEquipment newItem,MyEquipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    private void Awake()
    {
        instance = this;
        inventory = MyInventory.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        int i = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new MyEquipment[i];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            AllUnEquiped();
        }
    }
    public void AddEquipment(MyEquipment newEquipment)
    {
        int index = (int)newEquipment.slot;
        MyEquipment oldEquipment = null;
        if(currentEquipment[index] != null)
        {
            oldEquipment = currentEquipment[index];
            inventory.Add(oldEquipment);

        }
        if(onEquipmentChanged!=null)
        {
            onEquipmentChanged.Invoke(newEquipment, oldEquipment);
        }
        currentEquipment[index] = newEquipment;
    }

    public void UnEquipment(int slotIndex)
    {
        MyEquipment oldEquipment = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldEquipment = currentEquipment[slotIndex];
            inventory.Add(oldEquipment);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquipment);
            }
        }
    }
    
    public void AllUnEquiped()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquipment(i);
        }
    }
    
}
