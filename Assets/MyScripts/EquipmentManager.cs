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
    public SkinnedMeshRenderer[] currentMeshes;
    public SkinnedMeshRenderer targetMesh;
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
        currentMeshes = new SkinnedMeshRenderer[i];
        
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
        SetEquipmentBlendShapes(newEquipment, 100);
        currentEquipment[index] = newEquipment;
        SkinnedMeshRenderer newMesh = Instantiate(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[index]=newMesh;
    }

    public void UnEquipment(int slotIndex)
    {
        MyEquipment oldEquipment = null;
        if (currentEquipment[slotIndex] != null)
        {
            if(currentMeshes[slotIndex]!=null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            oldEquipment = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldEquipment, 0);
            inventory.Add(oldEquipment);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquipment);
            }
        }
    }

    public void SetEquipmentBlendShapes(MyEquipment item,int weight)
    {
        foreach (EquipmentRegion blendShapeItem in item.coveredRegion)
        {
            targetMesh.SetBlendShapeWeight((int)blendShapeItem, weight);
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
