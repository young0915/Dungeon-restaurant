using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CookToggleUI : MonoBehaviour
{
    public GameObject platetab;
    public Toggle baskettoggle;
    public Toggle source_platetoggle;

    private void OnEnable()
    {
        GameManager.Instance.cookingaLLwindow.SetActive(true);
        GameManager.Instance.cookingzone.SetActive(true);
        GameManager.Instance.dispanel.SetActive(true);
        GameManager.Instance.dishfrontpanel.SetActive(true);
        baskettoggle.isOn = true;
        source_platetoggle.isOn = false;
    }
    void Update()
    {
        if(baskettoggle.isOn)
        {
            GameManager.Instance.cookingaLLwindow.SetActive(true);
            GameManager.Instance.cookingzone.SetActive(true);
            GameManager.Instance.dispanel.SetActive(true);
            GameManager.Instance.dishfrontpanel.SetActive(true);
            GameManager.Instance.sourcepanel.SetActive(false);
        }
        else
        {
            GameManager.Instance.cookingzone.SetActive(false);
            if (GameManager.Instance.platedecowindow.activeSelf == true)
            {
                GameManager.Instance.platedecowindow.SetActive(true);
                platetab.SetActive(true);
            }
        
            if(GameManager.Instance.ovencookingwindow.activeSelf ==true)
            {
                GameManager.Instance.toggleobj.SetActive(true);
                GameManager.Instance.sourcebgtoggle.SetActive(true);
                GameManager.Instance.cookingaLLwindow.SetActive(true);
                GameManager.Instance.cookingzone.SetActive(true);
                GameManager.Instance.ovencookingwindow.SetActive(true);
                GameManager.Instance.sourcepanel.SetActive(true);
            }
            if(GameManager.Instance.potcookingwindow.activeSelf ==true)
            {
                GameManager.Instance.toggleobj.SetActive(true);
                GameManager.Instance.sourcebgtoggle.SetActive(true);
                GameManager.Instance.cookingaLLwindow.SetActive(true);
                GameManager.Instance.cookingzone.SetActive(true);
                GameManager.Instance.potcookingwindow.SetActive(true);
                GameManager.Instance.sourcepanel.SetActive(true);
            }
            if(GameManager.Instance.pancookingwindow.activeSelf == true)
            {
                GameManager.Instance.toggleobj.SetActive(true);
                GameManager.Instance.sourcebgtoggle.SetActive(true);
                GameManager.Instance.cookingaLLwindow.SetActive(true);
                GameManager.Instance.cookingzone.SetActive(true);
                GameManager.Instance.pancookingwindow.SetActive(true);
                GameManager.Instance.sourcepanel.SetActive(true);
            }

        }
        if (source_platetoggle.isOn)
        {
            if (GameManager.Instance.platedecowindow.activeSelf == true)
            {
                GameManager.Instance.platedecowindow.SetActive(true);
                platetab.SetActive(true);
            }
            if (GameManager.Instance.ovencookingwindow.activeSelf == true || GameManager.Instance.potcookingwindow.activeSelf == true ||
              GameManager.Instance.pancookingwindow.activeSelf == true)
            {
                GameManager.Instance.sourcepanel.SetActive(true);
            }
        }
        else
        {
            GameManager.Instance.cookingaLLwindow.SetActive(true);
            GameManager.Instance.cookingzone.SetActive(true);
            GameManager.Instance.dispanel.SetActive(true);
            GameManager.Instance.dishfrontpanel.SetActive(true);
            GameManager.Instance.sourcepanel.SetActive(false);
        }
    }
}
