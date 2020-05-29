using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateVegetable : MonoBehaviour
{
    public enum ORDERVEGETABLE
    {
        ORDER_ONION,
        ORDER_POTATO
    }
    public ORDERVEGETABLE order_vegetable;
    public GameObject selectvecgetablewindow;
    public ItemSlot[] itemslot;
    public float planettimer;
    public int sec;
    public GameObject sproutonion;                         //새싹양파이미지
    public GameObject fledgeonion;                          //양파가 다 자란 이미지 
    public GameObject sproutpotato;                        //새싹감자이미지
    public GameObject fledgepotato;                         //감자가 다 자란 이미지
    public GameObject addvegetablebutton;                //다 자란 후 버튼이 생기는 이미지
    private void Awake()
    {
        planettimer = 10;
    }

    private void Start()
    {
    }

    public void GoWayGarden()
    {
        selectvecgetablewindow.SetActive(true);
    }
    public void GoOutGarden()
    {
        selectvecgetablewindow.SetActive(false);
    }
    //양파를 심었을 때
    public void OnionClickButton()
    {
        StartCoroutine(StartOnion());
    }
    //감자 심었을 때 
    public void PotatoClickButton()
    {
        StartCoroutine(StartPotato());
    }
    //양파를 생성시키는 코루틴함수
    IEnumerator StartOnion()
    {
        planettimer -= Time.deltaTime;
        sec = Mathf.RoundToInt(planettimer);
        Debug.Log(sec);
        yield return null;
        OnionGrowup();
    }
    //
    IEnumerator StartPotato()
    {
        planettimer -= Time.deltaTime;
        sec = Mathf.RoundToInt(planettimer);
        Debug.Log(sec);
        yield return null;
        PotatoGrowup();
    }

    public void OnionGrowup()
    {
        //초가 지나면
        if(sec<=0)
        {
            //버튼을 생성시켜서 클릭하자
            //양파 생성          
             itemslot[0].itemCout += 1;
             fledgeonion.SetActive(false);
        }
        else
        {
            if(sec >=6)
            {
                //새싹
                sproutonion.SetActive(true);
            }
            if(sec == 5)
            {
                //식물 교체
                sproutonion.SetActive(false);
                fledgeonion.SetActive(true);
            }
            StartCoroutine(StartOnion());
        }
    }
    public void PotatoGrowup()
    {
        //초가 지나면
        if (sec <= 0)
        {
            //감자 생성
                itemslot[1].itemCout += 1;
                fledgepotato.SetActive(false);
        }
        else
        {
            if (sec >= 6)
            {
                //새싹
                sproutpotato.SetActive(true);
            }
            if (sec == 5)
            {
                //식물 교체
                sproutpotato.SetActive(false);
                fledgepotato.SetActive(true);
            }
            StartCoroutine(StartPotato());
        }
    }


}
