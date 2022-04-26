using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class MyEquipment : InventoryItem
{
    public int equipmentModifier;
    public int damageEquipmentModifier;
    public EquipmentSlot slot;
    public SkinnedMeshRenderer mesh;
    public EquipmentRegion[] coveredRegion; 

    public override void UseItem()
    {
        base.UseItem();
        EquipmentManager.instance.AddEquipment(this);
        Debug.Log("Using Equiment" + Name);
        RemoveFromInventory();
    }


}
public enum EquipmentSlot
{
    SHIELD,
    LEGS,
    HEAD,
    CHEST
}
public enum EquipmentRegion
{
    Legs,
    Arms,
    Torso
}
