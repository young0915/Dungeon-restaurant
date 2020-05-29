using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRecipe : MonoBehaviour
{
    public List<AllRecipeinfo> recipeinfos;
}
[System.Serializable]
public class AllRecipeinfo
{
    public Image foodimage;
    public RecipeManager recipemanagers;
}