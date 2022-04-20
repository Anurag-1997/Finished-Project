using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public MyEquipment[] currentEquipment;
    private void Awake()
    {
        instance = this;
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
        
    }
    public void AddEquipment(MyEquipment newEquipment)
    {
        int index = (int)newEquipment.slot;
        currentEquipment[index] = newEquipment;
    }
}
