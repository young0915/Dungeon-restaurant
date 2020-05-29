using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BasketSlot : MonoBehaviour, IDropHandler
{
    public enum BASITEMSTATE
    {
        DUNGEON_BASITEM_COCKROCH,
        DUNGEON_BASITEM_GIANTSPIDER,
        DUNGEON_BASITEM_GOBLIN,
        VEGETABLE_BASITEM_ONION,
        VEGETABLE_BASITEM_GARLIC,
        VEGETABLE_BASITEM_PIE,
        VEGETABLE_BASITEM_POTATO,
        SPECIAL_BASITEM_FISH,
        SPECIAL_BASITEM_ANIMEAT,
        BASKET_EMPTYITEM                                            //비어있는 상태 
    }
    public BASITEMSTATE basket_item;
   private RectTransform basketroot;
    public Button testbutton;
    public bool isstart;
    public ItemSlot[] itemslot;
    public GameObject[] itemimage;
    public List<GameObject> cockoachitem;
    public List<GameObject> goblineyeitem;
    public bool isempty;
    //초기화 상태로는 빈값으로 준다.
    private void Start()
    {
        basketroot = GameObject.Find("DishScrollRect").GetComponent<RectTransform>();
        cockoachitem = new List<GameObject>();
        basket_item = BASITEMSTATE.BASKET_EMPTYITEM;
        isempty = false;
    }
    //재료를 인벤토리로 옮겼을 때 
    public void OnDrop(PointerEventData eventData)
    {
        //바구니 상태도 알아야하며, 시각적으로 오브젝트도 보여줘야함 고블린 눈, 바퀴벌레는 두개 이상씩은 담아야함
        //아이템의 카운트가 떨어지는 것 또한 보여줘야함
        var item = ItemDragHandler._itemBeginDragged;
        //바구니에 무엇을 받았는지 아이템의 상태를 알아야하며
        basket_item = (BasketSlot.BASITEMSTATE)item.itemInfo.ID;
        Debug.Log("현재 "+ basket_item);
        //그 상태에 따라서 이미지가 생성되어야 한다.
        switch (basket_item)
        {
            case BASITEMSTATE.DUNGEON_BASITEM_COCKROCH:
                //수량에 따른 아이템 추가
                itemimage[0].SetActive(true);
                isstart = true;
                itemslot[0].itemCout -= 1;
                cockoachitem.Add(itemimage[0]);
                if(cockoachitem.Count ==2)
                {
                    itemimage[9].SetActive(true);
                }
                if (cockoachitem.Count == 3)
                {
                    itemimage[10].SetActive(true);
                }
                if (cockoachitem.Count == 4)
                {
                    itemimage[11].SetActive(true);
                }
                break;
            case BASITEMSTATE.DUNGEON_BASITEM_GIANTSPIDER:
                itemimage[1].SetActive(true);
                itemslot[1].itemCout -= 1;
                break;
            case BASITEMSTATE.DUNGEON_BASITEM_GOBLIN:
                itemimage[2].SetActive(true);
                itemslot[2].itemCout -= 1;
                break;
            case BASITEMSTATE.VEGETABLE_BASITEM_ONION:
                itemimage[3].SetActive(true);
                itemslot[3].itemCout -= 1;
                break;
            case BASITEMSTATE.VEGETABLE_BASITEM_GARLIC:
                itemslot[4].itemCout -= 1;
                itemimage[4].SetActive(true);
                break;
            case BASITEMSTATE.VEGETABLE_BASITEM_PIE:
                itemimage[6].SetActive(true);
                itemslot[6].itemCout -= 1;
                break;
            case BASITEMSTATE.VEGETABLE_BASITEM_POTATO:
                itemslot[5].itemCout -= 1;
                itemimage[5].SetActive(true);
                break;
            case BASITEMSTATE.SPECIAL_BASITEM_FISH:
                itemimage[7].SetActive(true);
                itemslot[7].itemCout -= 1;
                break;
            case BASITEMSTATE.SPECIAL_BASITEM_ANIMEAT:
                itemimage[8].SetActive(true);
                itemslot[8].itemCout -= 1;
                break;
            case BASITEMSTATE.BASKET_EMPTYITEM:
                //쓰레기 버리는 버튼으로 사용할 것
                basket_item = BASITEMSTATE.BASKET_EMPTYITEM;
                for(int i =0; i<itemimage.Length; i++)
                {
                    itemimage[i].SetActive(false);
                }
                //전체 다 지우기 
                break;
        }
    }
    
}
