using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RoastCooking : MonoBehaviour,IBeginDragHandler, IDragHandler,IEndDragHandler
{
    private RectTransform Panroot;                                                  //조리기구
    public bool ispushobject;                                                          //조리기구에 물체가 닿으면 체크할 것 
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        Panroot = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        Panroot.anchoredPosition += eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
