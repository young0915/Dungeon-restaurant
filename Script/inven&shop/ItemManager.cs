using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ItemManager : MonoBehaviour
{
    public Item itemInfo;
    [ContextMenu("To Json Data")]
    void SaveDataToJson()
    {
        string jsonData = JsonUtility.ToJson(itemInfo);
        string path = Application.dataPath + "/Resource/Data/" + itemInfo.Nickname + ".json";

        File.WriteAllText(path, jsonData);
    }
}

[System.Serializable]
public class Item
{   public int ID;
    public string Nickname;
    public string ItemName;
    public int ItemPrice;
    public float ItemTimer;
    public int ItemAllPrice;
}