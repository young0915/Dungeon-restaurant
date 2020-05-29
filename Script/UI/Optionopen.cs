using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optionopen : MonoBehaviour
{
    public GameObject optionwindow;
    //옵션 오픈창
    public void Openoptionwindow()
    {
        optionwindow.SetActive(true);
        GameManager.Instance.customerinfobtn.SetActive(false);
    }
    //옵션 닫기
    public void Closeoptionwindow()
    {
        optionwindow.SetActive(false);
        GameManager.Instance.customerinfobtn.SetActive(true);

    }
}
