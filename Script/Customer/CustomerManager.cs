using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CustomerManager : MonoBehaviour
{
    public Customer cusinfo;

    [ContextMenu("To Json Data")]
    void SaveDataToJson()
    {
        string jsonData = JsonUtility.ToJson(cusinfo);
        string path = Application.dataPath + "/Resource/CustomerData/" + cusinfo.nickname + ".json";
        File.WriteAllText(path, jsonData);
    }
}

[System.Serializable]
public class Customer
{
    public int id;
    public int customerid;
    public string customerrating;
    public string customername;
    public string nickname;
    public int wantfood;
    public float timer;
    public string[] customerscript;
}