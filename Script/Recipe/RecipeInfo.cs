using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeInfo : MonoBehaviour
{
    public RecipeManager[] recipe;
    public Text FoodTitile;
    public Text fooddescript;
    public GameObject RecipePanel;
    // Start is called before the first frame update
    public void RecipeOpen(int d)
    {
        RecipePanel.SetActive(true);
        d = recipe[d].recipeinfo.id;
        FoodTitile.text = recipe[d].recipeinfo.Titledescript;
        fooddescript.text = recipe[d].recipeinfo.cookrecipedescript;
    }
    public void CloseButton()
    {
        RecipePanel.SetActive(false);
    }

}
