using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCheck : MonoBehaviour
{
    public QuestOrder quest_order;
    public Image[] itemimage;                                                       //아이템 이미지
    public Text itemname;                                                           //아이템 이름                  
    public Text itemcount;                                                           //아이템 수량
    public Text itemPrice;                                                             //아이템 개당 가격
    public Text itemtimer;                                                           //아이템 타이머 
    public Text  allitemPrice;                                                         //아이템 보수금

    // Start is called before the first frame update
    private void OnEnable()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartOrder();

    }


    public void StartOrder()
    {
        //이미지  생성
        if (quest_order.quest_type == QuestOrder.QUESTGOITEM.QUEST_GO_COCKROACH)
        {
            itemimage[0].enabled = true;
            itemimage[1].enabled = false;
            itemimage[2].enabled = false;
        }
        if (quest_order.quest_type == QuestOrder.QUESTGOITEM.QUEST_GO_COCKROACH)
        {
            itemimage[0].enabled = false;
            itemimage[1].enabled = true;
            itemimage[2].enabled = false;
        }
        if (quest_order.quest_type == QuestOrder.QUESTGOITEM.QUEST_GO_COCKROACH)
        {
            itemimage[0].enabled = false;
            itemimage[1].enabled = false;
            itemimage[2].enabled = true;
        }
        itemname.text = quest_order.itemName.text + quest_order.itemCount.text + "개 구해오기";
        itemPrice.text = " 개당 가격 : " + quest_order.itemPrice.text;
        itemcount.text = " 개 수  : " + quest_order.itemCount.text;
        allitemPrice.text = " 보수금  : " + quest_order.itemAllPrice.text;
        itemtimer.text = " 남은 시간  : " + quest_order.sec;
    }
}
