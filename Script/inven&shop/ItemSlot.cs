using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemManager item;
    public Text itemname;
    public Text WhatisitemCount;
    public Image itemImage;
    public GameObject soldoutImage;
    public int itemCout;

    private void OnEnable()
    {
        itemname.text = item.itemInfo.ItemName;
    }

 
    private void Update()
    {
        WhatisitemCount.text = itemCout.ToString();
        if (itemCout>0)
        {
            soldoutImage.SetActive(false);
        }
        else
        {
            soldoutImage.SetActive(true);
        }
    }

    public ItemManager GetItem() { return item; }
}
