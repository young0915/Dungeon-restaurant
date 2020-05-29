using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestOrder : MonoBehaviour
{
   public enum QUESTGOITEM
    {
        QUEST_GO_COCKROACH,
        QUEST_GO_SPIDER,
        QUEST_GO_GOBLINEYE
    }
   public QUESTGOITEM quest_type;
   public QuestCheck questcheckwindow;                         //넘겨주었을 때생성되는 탭창 
    public GameObject QuestOrderpanel;
    public ItemManager[] itemmanager;                             //아이템매니저
    public ItemSlot[] questitemslot;                                   //아이템 슬롯
    public Text itemName;                                             //아이템 이름
    public Text itemTimer;                                              //아이템 개당 시간
    public Text itemPrice;                                                //개당 금액
    public Text itemCount;                                              //아이템 현재 수량
    public Text itemAllPrice;                                            //아이템 보스금
    public Slider itemCountslider;                                     //수량 처리
    public Image QuestImg;
    public GameObject[] itemimage;
    public GameObject QuestWindowScroll;
    public GameObject[] questchecktabar;
    public bool isqueststart;                                   //퀘스트 시작

    public float questtime;
     public int sec;
    private void OnEnable()
    {
        questtime = 10;
        itemCountslider.value = 0;      //0으로 셋팅
    }
    private void Update()
    {
        itemCount.text = "수량 : " + Mathf.RoundToInt(itemCountslider.value * 10).ToString();
       
    }


    public void ItemCountSliders()
    {
       float  ItemCount = itemCountslider.value;
    }

    public void CockachOrderButton()
    {
        questchecktabar[0].SetActive(true);
        quest_type = QUESTGOITEM.QUEST_GO_COCKROACH;
        QuestOrderpanel.SetActive(true);
        itemimage[0].SetActive(true);
        itemimage[1].SetActive(false);
        itemimage[2].SetActive(false);
        itemName.text = " 이름 : " + itemmanager[0].itemInfo.ItemName;
        itemTimer.text = "개당 시간  : " + itemmanager[0].itemInfo.ItemTimer.ToString();
        itemPrice.text = "개당 금액  : " + itemmanager[0].itemInfo.ItemPrice.ToString();
        itemCount.text = "수량 : " + Mathf.RoundToInt(itemCountslider.value * 10).ToString();
        itemAllPrice.text = "보수금 : " + itemmanager[0].itemInfo.ItemAllPrice;
    }
    public void GiantSpiderOrderButton()
    {
        questchecktabar[1].SetActive(true);
        quest_type = QUESTGOITEM.QUEST_GO_SPIDER;
        QuestOrderpanel.SetActive(true);
        itemimage[0].SetActive(false);
        itemimage[1].SetActive(true);
        itemimage[2].SetActive(false);
        itemName.text = " 이름 : " + itemmanager[1].itemInfo.ItemName;
       itemTimer.text = "개당 시간  : " + itemmanager[1].itemInfo.ItemTimer.ToString();
        itemPrice.text = "개당 금액  : " + itemmanager[1].itemInfo.ItemPrice.ToString();
        itemCount.text = "수량 : " + Mathf.RoundToInt(itemCountslider.value * 10).ToString();
        itemAllPrice.text = "보수금 : " + itemmanager[1].itemInfo.ItemAllPrice;
    }
    public void GoblinEyeOrderButton()
    {
        questchecktabar[2].SetActive(true);
        quest_type = QUESTGOITEM.QUEST_GO_GOBLINEYE;
        QuestOrderpanel.SetActive(true);
        itemimage[0].SetActive(false);
        itemimage[1].SetActive(false);
        itemimage[2].SetActive(true);
        itemName.text = " 이름 : " + itemmanager[2].itemInfo.ItemName;
        itemTimer.text = "개당 시간  : " + itemmanager[2].itemInfo.ItemTimer.ToString();
        itemPrice.text = "개당 금액  : " + itemmanager[2].itemInfo.ItemPrice.ToString();
        itemCount.text = "수량 : " + Mathf.RoundToInt(itemCountslider.value * 10).ToString();
        itemAllPrice.text = "보수금 : " + itemmanager[2].itemInfo.ItemAllPrice;
    }

    //체크완료
    public void FinishedCheckButton()
    {
        QuestWindowScroll.SetActive(true);
        questcheckwindow.StartOrder();
        //코루틴 사용할 것
        StartCoroutine(QuestTime());
    }

   public void CancleButton()
    {
        QuestOrderpanel.SetActive(false);
    }

    IEnumerator QuestTime()
    {
        questtime -= Time.deltaTime;
        sec = Mathf.RoundToInt(questtime);
        yield return null;
        DownTime();
    }

    void DownTime()
    {
        //타이머 끝
        if (sec == 0)
        {
            //내가 주문한 아이템들
            if(quest_type == QUESTGOITEM.QUEST_GO_COCKROACH)
            {
                questchecktabar[0].SetActive(false);
                //바퀴벌레 발주 완료
                //아이템 채움
                questitemslot[0].itemCout += Mathf.RoundToInt(itemCountslider.value*10);
                // 플레이어에서 돈 빠져나감 
                GameManager.Instance.playermoneyint -= itemmanager[0].itemInfo.ItemAllPrice;
            }
            //내가 주문한 아이템들
            if (quest_type == QUESTGOITEM.QUEST_GO_SPIDER)
            {
                questchecktabar[1].SetActive(false);
                //거미 발주 완료
                //아이템 채움
                questitemslot[1].itemCout += Mathf.RoundToInt(itemCountslider.value*10);
                // 플레이어에서 돈 빠져나감 
                GameManager.Instance.playermoneyint -= itemmanager[1].itemInfo.ItemAllPrice;
            }
            //내가 주문한 아이템들
            if (quest_type == QUESTGOITEM.QUEST_GO_GOBLINEYE)
            {
                questchecktabar[2].SetActive(false);
                //고블린 발주완료
                //아이템 채움
                questitemslot[2].itemCout += Mathf.RoundToInt(itemCountslider.value*10);
                // 플레이어에서 돈 빠져나감 
                GameManager.Instance.playermoneyint -= itemmanager[2].itemInfo.ItemAllPrice;
            }
        }
        else
        {
            StartCoroutine(QuestTime());
            QuestWindowScroll.SetActive(false);
        }
    }


}
