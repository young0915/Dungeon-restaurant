using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject CompanyLogo;
    public GameObject GameSatartButton;                     //게임 스타트 버튼 
    public GameObject NextButton;
    public GameObject IntroDialogPanel;                     //시작 게임에 넣을 곳
    public GameObject DialogSpriteOne;
    public GameObject DialogSpriteTwo;
    public GameObject DialogSpriteThree;
    public AudioSource introbgm;
    public UILabel DialogLable;
    public string[] DialogDescript;
    public float typingSpeed;
    private int index;

    private void Start()
    {
        introbgm.Play();
        StartCoroutine(CompanyLogoDown());
    }

    IEnumerator CompanyLogoDown()
    {
        yield return new WaitForSeconds(11.0f);
        CompanyLogo.SetActive(false);
        IntroDialogPanel.SetActive(true);
        StartCoroutine(Type()); 
    }

    //텍스트 출력하는 곳 
    IEnumerator Type()
    {
        foreach(char letter in DialogDescript[index].ToCharArray())
        {
            DialogLable.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextDialogButton()
    {
        DialogLable.text = string.Empty;
        if (index < DialogDescript.Length - 1)
        {
            index++;
            //대화 이미지 출력 하는 부분
            #region
            if (index ==1)
            {
                DialogSpriteOne.SetActive(true);
                DialogSpriteTwo.SetActive(false);
                DialogSpriteThree.SetActive(false);
            }
            if(index ==2)
            {
                DialogSpriteOne.SetActive(false);
                DialogSpriteTwo.SetActive(true);
                DialogSpriteThree.SetActive(false);
            }
            if(index ==3)
            {
                DialogSpriteOne.SetActive(false);
                DialogSpriteTwo.SetActive(false);
                DialogSpriteThree.SetActive(true);
                StartCoroutine(GoStart());
            }
            #endregion
            DialogLable.text += "";
            StartCoroutine(Type());                                                         //다시 반복
        }
    }

    IEnumerator GoStart()
    {
        yield return new WaitForSeconds(1.8f);
        IntroDialogPanel.SetActive(false);                                           //버튼을 네번 클릭하면 인트로 패널은 사라짐                       
        GameSatartButton.SetActive(true);                                            //게임스타트
        introbgm.Stop();
    }


}
