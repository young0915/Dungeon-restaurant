using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potcooking : MonoBehaviour
{
    public bool cookboilstart;
    public float cookmin;
    int liecookmin;
    public GameObject[] soupimg;
    public BasketSlot basket_slot;
    private void OnEnable()
    {
        cookmin = 0.0f;
        cookboilstart = false;
    }
    void Update()
    {
        if (GameManager.Instance.potcookingwindow.activeSelf == true)
        {
            cookboilstart = true;
        }
        else
        {
            cookboilstart = false;
        }
        if (cookboilstart)
        {
            soupimg[0].SetActive(true);
            soupimg[1].SetActive(true);
           cookmin += Time.deltaTime;
           liecookmin = Mathf.RoundToInt(cookmin);
                if (liecookmin >= 4)
                {
                    //바퀴벌레일 경우 
                    if (basket_slot.isstart)
                    {
                        soupimg[0].SetActive(false);
                        soupimg[1].SetActive(false);
                        soupimg[2].SetActive(true);                                                             //고쿠라치 스프색깔
                        soupimg[3].SetActive(true);                                                             //고쿠라치 스프색깔
                        soupimg[4].SetActive(false);
                        soupimg[5].SetActive(false);

                    }
                    //생선일 경우
                    else
                    {
                        soupimg[0].SetActive(false);
                        soupimg[1].SetActive(false);
                        soupimg[2].SetActive(false);                                                             //고쿠라치 스프색깔
                        soupimg[3].SetActive(false);                                                             //고쿠라치 스프색깔
                        soupimg[4].SetActive(true);                                                              //생선
                        soupimg[5].SetActive(true);                                                              //생선

                    }
            }
        }
    }
}
