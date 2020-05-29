using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text curentcoinscore;
    public Text businessday;
    public Text accumulatecustomer;
    public Text Averagescore;
    public Text accumulatecoin;
    public CustomerMove customercount;
    public int day=0;
    private void OnEnable()
    {
        StartCoroutine(scoreday());
    }

    // Update is called once per frame
    void Update()
    {
        curentcoinscore.text = " 보유 골드 : "+GameManager.Instance.playermoneyint.ToString();                                            //식당상태_현재 골드 
        businessday.text =" 장사 "+ day.ToString()+"일째";
        accumulatecustomer.text = " 누적 손님 : "+customercount.maxcustomer.ToString();
        accumulatecoin.text = " 누적 골드 : " + GameManager.Instance.playermoneymin;

        if ((GameManager.Instance.playerscore/3) >= 70)
        {
            Averagescore.text = " 평균 : " + "  A   " + "등급";
        }
        else if ((GameManager.Instance.playerscore / 3) >= 50)
        {
            Averagescore.text = " 평균 : " + "  B   " + "등급";
        }
        else {
            Averagescore.text = " 평균 : " + "  C   " + "등급";
        }
    }

    IEnumerator scoreday()
    {
        day += 1;
        yield return null;
    }


}
