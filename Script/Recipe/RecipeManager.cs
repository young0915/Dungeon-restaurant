using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecipeManager : MonoBehaviour
{
    public Recipe recipeinfo;

    [ContextMenu("To Json Data")]
    void SaveDataToJson()
    {
        string jsonData = JsonUtility.ToJson(recipeinfo);
        string path = Application.dataPath + "/Resource/RecipeData/" + recipeinfo.nickname + ".json";

        File.WriteAllText(path, jsonData);
    }
}
[System.Serializable]
public class Recipe
{
    public int id;
    public string nickname;
    public string foodname;
    public string foodtype;
    public int foodprice;
    public int recipeprice;
    public int Mainmaterial;
    public int Mainsource;
    [TextArea]
    public string cookrecipedescript;
    [TextArea]
    public string Titledescript;
}
