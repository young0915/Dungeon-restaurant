using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SAUCEETYPE
{
    SOLT_TYPE,
    SUGER_TYPE
}

public class sourcedraghandler : MonoBehaviour ,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SAUCEETYPE source_type;
    public AllRecipe all_recipe;
    public Button saucebtn;
    public GameObject saucespoonimg;
    Vector2 pos;
    Camera Camera;

    private void Awake()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void Sauceusebtn()
    {
        saucespoonimg.SetActive(true);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        pos = Input.mousePosition;
        pos = Camera.ScreenToWorldPoint(pos);
        saucespoonimg.transform.position = pos;
        //(조건) 레시피와 동일한지 
                GameManager.Instance.playerscore += (int)GameManager.GameScore.GAME_TASTE_FOOD;
        Debug.Log(source_type);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        saucespoonimg.transform.position = new Vector2(saucebtn.transform.position.x, saucebtn.transform.position.y);
        saucespoonimg.SetActive(false);
    }

}
