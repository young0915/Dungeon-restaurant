using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecipeSlot : MonoBehaviour
{
    /// <summary>
    /// RecipeSlot 변수들
    /// </summary>
    #region
    public enum KINDOFRECIPE
    {
        COCKOACH_MIXED,
        COCKOACH_SOUP,
        GIANTSPIDER_PIE,
        GOBLINEYE_SOUP
    }
    public KINDOFRECIPE kindof_recipe;
    public RecipeManager recipe;
    public Image foodimage;
    public Text foodname;
    public Text foodtype;
    public Text Recipeprice;
    public Text foodprice;
    public GameObject RecipeBuyButton;
    public GameObject RecipeOnButton;
    public RecipeInfo recipeinfo;
    #endregion
    // Update is called once per frame
    void Update()
    {
        if (kindof_recipe == (KINDOFRECIPE)recipe.recipeinfo.id)
        {
            foodname.text = recipe.recipeinfo.foodname;
            foodtype.text = "조리타입 : " +  recipe.recipeinfo.foodtype;
            Recipeprice.text =  recipe.recipeinfo.recipeprice.ToString();
            foodprice.text = "판 매 가 : " + recipe.recipeinfo.foodprice.ToString();
        }
    }

    //레시피 구매 버튼
    public void BuyRecipeButton()
    {
        if (kindof_recipe == (KINDOFRECIPE)recipe.recipeinfo.id)
        {
            RecipeBuyButton.SetActive(false);
            RecipeOnButton.SetActive(true);
            GameManager.Instance.playermoneyint -= recipe.recipeinfo.recipeprice;
        }
    }
    //레시피 정보 버튼
    public void InfoOnRecipeButton()
    {
        recipeinfo.RecipeOpen(recipe.recipeinfo.id);
    }
}
