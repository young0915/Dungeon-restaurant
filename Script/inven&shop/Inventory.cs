using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform slotRoot;                                     //층을 맞추기 위한 것 
    public List<ItemSlot> slots;                                    //슬롯 정리

    private void Start()
    {
        slots = new List<ItemSlot>();

        int slotCnt = slotRoot.childCount;

        for(int i = 0; i< slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<ItemSlot>();
            slots.Add(slot);
        }
    }
}
