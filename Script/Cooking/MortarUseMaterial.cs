using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MortarUseMaterial : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransfrom;
    void Awake()
    {
        rectTransfrom = GetComponent<RectTransform>();
    }

    //IPointDownHandler, IBeginDragHandler를 사용하는 이벤트 함수들
    #region
    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransfrom.anchoredPosition += eventData.delta;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    //방망이에 Collider2d 추가하기 
    //Trigger함수 이용
    #endregion
}
