using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//다 만들면 #region 이용해서 정리
public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static ItemManager _itemBeginDragged;
    public ItemManager item;
    public Transform itemimg;
    Vector2 pos;
    Camera Camera;
    Transform _starParent;
    public ItemSlot itemslot;
    public BasketSlot[] baksetslot;

    private void Awake()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemBeginDragged = gameObject.GetComponentInParent<ItemSlot>().GetItem();
        _starParent = transform.parent;
        transform.SetParent(GameObject.Find("InvenScrollRect").transform);
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemslot.itemCout<= 0) return;
        else
        pos = Input.mousePosition;
        pos = Camera.ScreenToWorldPoint(pos);
        itemimg.transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         transform.SetParent(_starParent);
        _itemBeginDragged = null;
        GetComponent<Image>().raycastTarget = true;
    }
}
