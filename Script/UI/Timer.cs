using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//전체 시간용
public class Timer : MonoBehaviour
{
    public GameObject BookPanel;                            //BookPanel
    public GameObject Book;                                   //Book결과창
    public GameObject scorepanel;
    public GameObject resultwindow;                                                                                                       //결과창
    public Text TimerUi;                                                                                                                                   //타이머 텍스트
    public  float min = 209;                                                                                                                                          // 주어진 분
    int lieint;
    int sec;                                                                                                                                                          //주어진 초

    private void FixedUpdate()
    {
        min -= Time.deltaTime;                                                                                                    //Time.dletime으로 이용하여  뺀다
        lieint = Mathf.RoundToInt(min) / 60;
        sec = Mathf.RoundToInt(min % 60);                                                                                                  //초를 분으로 나누어 반환
        if (sec == 60)                                                                                                                                           //60초이면 0으로 수정할 것 
        {
            sec = 0;
        }
        TimerUi.text = lieint + ":" + sec;                                              //결과
        if (lieint == 0 && sec == 0)
        {
            BookPanel.SetActive(true);
            Book.SetActive(true);
            resultwindow.SetActive(true);                                                                                                      //게임 종료
            Time.timeScale = 0;                                                                                                                          //시간 멈춤->       Time.timeScale = 1f;           
        }
    }
}


///홀수로 게임을 끝낼 것
//        for(int i =0; i<customer_move.customerint; i++)
//        {
//            if (i % 2 == 0) return;
//            else
//            {

//            }
//        }