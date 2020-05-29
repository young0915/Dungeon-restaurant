using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketInventory : MonoBehaviour
{
    public Transform BasketRoot;
    public List<BasketSlot> Basketslots;
    void Start()
    {
        Basketslots = new List<BasketSlot>();
        int BasketSlotCnt = BasketRoot.childCount;

        for(int i = 0; i<BasketSlotCnt;i++)
        {
            var basketslot = BasketRoot.GetChild(i).GetComponent<BasketSlot>();
            Basketslots.Add(basketslot);
            
        }
    }
}
