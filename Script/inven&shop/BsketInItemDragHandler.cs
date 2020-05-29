using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BsketInItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform basketroot;
    public BasketSlot basket_slot;
    public Image itemimg;                                               //바구니에 있는 이미지
    public GameObject itemobj;                                              //UI 이미지에서 sprite로 변환할 오브젝트

    private void Start()
    {
        basketroot = GetComponent<RectTransform>();

      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        basketroot.anchoredPosition = eventData.delta;
    }
    //아이템을 바닥에 내려놓는 순간 떨어짐
    public void OnEndDrag(PointerEventData eventData)
    {
        basket_slot.basket_item = BasketSlot.BASITEMSTATE.BASKET_EMPTYITEM;
        itemobj.SetActive(true);
        itemimg.enabled = false;
        StartCoroutine(dropitem());
        if(GameManager.Instance.ovencookingwindow.activeSelf ==true)
        {
            SoundManager.instance.effectbgm[4].Play();
        }
    }
    IEnumerator dropitem()
    {
        itemobj.GetComponent<SpriteRenderer>().enabled = true;
        yield return null;
    }

}
