using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMove : MonoBehaviour
{
    public enum Customertaste
    {
        CUSTOMERNOTDELICIOUS,
        CUSTOMERDELICIOUS
    }
 /// <summary>
 /// customer의 변수 모음
 /// </summary>
    #region
    public Customertaste customer_state;
    public RecipeSlot[] recipe_slot;
    public ItemSlot[] items_slot;
    public AllRecipe all_recipe;
    public Customerslots customer_slots;
    public SpriteRenderer Customerimg;
    public Text foodname;
    public Text makecookingtext;
    public Text speachtext;
    public Text customertimer;
    public Text customername;
    public GameObject speachImg;
    public GameObject RecipeButton;
    public GameObject wantcookpanle;
    public GameObject customercoin;
    public Image customerinfoimg;
    public Image foodimg;
    public int rndimg;
    public bool customerisgo =true;
    public bool orderisstart;
    public float speed =5;
    private float cusmin = 89;
    private int liemin;
    private int sec;
    private Timer timer;

    BoxCollider2D boxcollider;
    BoxCollider2D customercollider;                         //커스터머 콜라이더
    int closecustomer=-1;
    public int customerint;                                     //사람 몇명이나 왔는지 확인 
     public int maxcustomer;
    #endregion

    //포탈 오브젝트를 이용하여 손님 나오게 하기 
    //랜덤을 이용하여 손님 랜덤으로 나오게 하기
    private void Start()
    {
        customercollider = GameObject.Find("Customer").GetComponent<BoxCollider2D>();
        boxcollider = GameObject.Find("Entrancedoor").GetComponent<BoxCollider2D>();
       StartCoroutine(RandomCustomerimg());
        timer = GameObject.Find("AllTimerTabbar").GetComponent<Timer>();
    }
    private void FixedUpdate()
    {
        switch (rndimg)
        {
            case 0:
                customername.text = customer_slots.customers[0].customermanager.cusinfo.customername;
                customerinfoimg.sprite = customer_slots.customers[0].customerimg[0];
                foodimg.sprite = all_recipe.recipeinfos[0].foodimage.sprite;
                foodname.text = all_recipe.recipeinfos[0].recipemanagers.recipeinfo.foodname;
                makecookingtext.text = all_recipe.recipeinfos[0].recipemanagers.recipeinfo.cookrecipedescript;
                break;
            case 1:
                customername.text = customer_slots.customers[1].customermanager.cusinfo.customername;
                customerinfoimg.sprite = customer_slots.customers[1].customerimg[1];
                foodimg.sprite = all_recipe.recipeinfos[1].foodimage.sprite;
                foodname.text = all_recipe.recipeinfos[1].recipemanagers.recipeinfo.foodname;
                makecookingtext.text = all_recipe.recipeinfos[1].recipemanagers.recipeinfo.cookrecipedescript;
                break;
            case 2:
                customername.text = customer_slots.customers[2].customermanager.cusinfo.customername;
                customerinfoimg.sprite = customer_slots.customers[2].customerimg[2];
                foodimg.sprite = all_recipe.recipeinfos[2].foodimage.sprite;
                foodname.text = all_recipe.recipeinfos[2].recipemanagers.recipeinfo.foodname;
                makecookingtext.text = all_recipe.recipeinfos[2].recipemanagers.recipeinfo.cookrecipedescript;
                break;
            case 3:
                customername.text = customer_slots.customers[3].customermanager.cusinfo.customername;
                customerinfoimg.sprite = customer_slots.customers[3].customerimg[3];
                foodimg.sprite = all_recipe.recipeinfos[4].foodimage.sprite;
                foodname.text = all_recipe.recipeinfos[4].recipemanagers.recipeinfo.foodname;
                makecookingtext.text = all_recipe.recipeinfos[4].recipemanagers.recipeinfo.cookrecipedescript;
            
                break;
            case 4:
                customername.text = customer_slots.customers[4].customermanager.cusinfo.customername;
                customerinfoimg.sprite = customer_slots.customers[4].customerimg[3];
                foodimg.sprite = all_recipe.recipeinfos[5].foodimage.sprite;
                foodname.text = all_recipe.recipeinfos[5].recipemanagers.recipeinfo.foodname;
                makecookingtext.text = all_recipe.recipeinfos[5].recipemanagers.recipeinfo.cookrecipedescript;
              
                break;
        }
        //bool 값을 넣어야하나
        if (customerisgo)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (orderisstart)
        {
            cusmin -= Time.deltaTime;
            liemin = Mathf.RoundToInt(cusmin) / 60;
            sec = Mathf.RoundToInt(cusmin % 60);
            if (sec == 60)
            {
                sec = 0;
            }
            customertimer.text = liemin + " : " + sec;
            if (liemin == 0 && sec == 0)
            {
                StartCoroutine(TImeOver());
            }
        }
        else
        {
            if (!customerisgo)
            {
                speed = 5;
                transform.Translate(Vector2.left * (speed) * Time.deltaTime);
            }
            customertimer.text = " -- : -- ";
        }
         //재료손질창이 뜬다면 잠시 손님의 콜라이더는 잠시 꺼둘 것
        if (GameManager.Instance.materialcarepanel.activeSelf ==true || GameManager.Instance.bearcookingwindow.activeSelf == true  ||
          GameManager.Instance.pancookingwindow.activeSelf == true || GameManager.Instance.finishedfoodwindow.activeSelf == true
       ||GameManager.Instance.ovencookingwindow.activeSelf == true)
        {
            customercollider.enabled = false;
        }
        //가게마감하기
        //홀수로 마감할 것이며 시간타이머 리셋시킬 것
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="customerwall")
        {
            speachImg.SetActive(true);
            StartCoroutine(WelcomeDialog());
            speed = 0;
        }
        if(collision.tag == "entranceddoor")
        {
           // Debug.Log("손님나감");
            Customerimg.enabled = false;
            speed = 0;
            //나중에 다시 넣을 것
            //StartCoroutine(CreateCustomer());
            //짝수니깐 
            if(customerint== closecustomer + 2)
            {
                StartCoroutine(resetcustomerscore());
                closecustomer += 2;
            }
            else
            {
                StartCoroutine(CreateCustomer());
            }
            //maxcustomer += 1;
        }
    }
    public void foodjudgment(Customertaste customertaste)
    {
        switch(customer_state)
        {
            case Customertaste.CUSTOMERNOTDELICIOUS:
                StartCoroutine(CUSTOMERNOTDELICIOUS());
                break;
            case Customertaste.CUSTOMERDELICIOUS:
                StartCoroutine(CUSTOMERDELICIOUS());
                break;
        }
    }

    //손님 랜덤으로 뽑기
    IEnumerator RandomCustomerimg()
    {
        SoundManager.instance.effectbgm[1].Play();
        
        Customerimg.enabled = true;
        customercollider.enabled = true;
        rndimg = Random.Range(0, 5);
        switch (rndimg)
        {
            case 0:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[0].customerimg;
                Customerimg.sprite = customer_slots.customers[0].customerimg[0];
                break;
            case 1:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[1].customerimg;
                Customerimg.sprite = customer_slots.customers[1].customerimg[0];
                break;
            case 2:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[2].customerimg;
                Customerimg.sprite = customer_slots.customers[2].customerimg[0];
                break;
            case 3:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[3].customerimg;
                Customerimg.sprite = customer_slots.customers[3].customerimg[0];
                items_slot[0].itemCout += 1;
                break;
            case 4:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[4].customerimg;
                Customerimg.sprite = customer_slots.customers[4].customerimg[0];
                items_slot[1].itemCout += 1;
                break;
        }
        yield return null;
    }
    //손님 인사 +레시피 확인
    IEnumerator WelcomeDialog()
    {
        //(조건)
        //손님(번호)과 일치한 대화를 출력해야한다.
        for(int i = 0; i <2; i++)
        {
            speachtext.text = customer_slots.customers[rndimg].customermanager.cusinfo.customerscript[i];
            yield return new WaitForSeconds(1.0f);
        }
        //손님이 주문한 음식 레시피가 오픈이 되어있지 않다면
        if(rndimg ==2)
        {
            if (recipe_slot[rndimg].RecipeBuyButton.activeSelf == true)
            {
                StartCoroutine(nomaterialcutstomereaction());
            }
            else
            {
                StartCoroutine(NextDialogOrder());
            }
        }
        else
        {
            StartCoroutine(NextDialogOrder());
        }
    }
    //주문서 떠야함
    IEnumerator NextDialogOrder()
    {
        speachImg.SetActive(false);
        wantcookpanle.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        wantcookpanle.SetActive(false);
        RecipeButton.SetActive(true);
        orderisstart = true;
        boxcollider.enabled = true;
        yield return null;
    }
    //타임오버
    IEnumerator TImeOver()
    {
        orderisstart = false;
        customerisgo = false;
        RecipeButton.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        customercollider.enabled = true;
        //
        //손님 생성
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(CreateCustomer());
    }
    //손님 생성
    IEnumerator CreateCustomer()
    {
        yield return new WaitForSeconds(1.0f);
        boxcollider.enabled = false;
        customerisgo = true;    
        cusmin = 89;                                                                // 초 충전
        StartCoroutine(RandomCustomerimg());                              // 다시 돌아가기
    }
    //맛없는 반응
    IEnumerator CUSTOMERNOTDELICIOUS()
    {
        //(조건)
        //표정이 달라짐
        switch (rndimg)
        {
            case 0:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[0].customerimg;
                Customerimg.sprite = customer_slots.customers[0].customerimg[2];
                break;
            case 1:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[1].customerimg;
                Customerimg.sprite = customer_slots.customers[1].customerimg[2];
                break;
            case 2:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[2].customerimg;
                Customerimg.sprite = customer_slots.customers[2].customerimg[2];
                break;
            case 3:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[3].customerimg;
                Customerimg.sprite = customer_slots.customers[3].customerimg[2];
                break;
            case 4:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[4].customerimg;
                Customerimg.sprite = customer_slots.customers[4].customerimg[2];
                break;
        }
        speachImg.SetActive(true);
        customercoin.SetActive(true);
        RecipeButton.SetActive(false);
        maxcustomer += 1;
        customerint += 1;
        speachtext.text = customer_slots.customers[rndimg].customermanager.cusinfo.customerscript[3];
        yield return new WaitForSeconds(0.8f);
        speachImg.SetActive(false);
        customer_state = Customertaste.CUSTOMERNOTDELICIOUS;
        GameManager.Instance.customercrush.value -= 0.1f;               //맛없으니 감소 
        //퇴장
        StartCoroutine(TImeOver());
        yield return null;
    }
    //맛있음
    IEnumerator CUSTOMERDELICIOUS()
    {
        switch (rndimg)
        {
            case 0:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[0].customerimg;
                Customerimg.sprite = customer_slots.customers[0].customerimg[3];
                break;
            case 1:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[1].customerimg;
                Customerimg.sprite = customer_slots.customers[1].customerimg[3];
                break;
            case 2:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[2].customerimg;
                Customerimg.sprite = customer_slots.customers[2].customerimg[3];
                break;
            case 3:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[3].customerimg;
                Customerimg.sprite = customer_slots.customers[3].customerimg[3];
                break;
            case 4:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[4].customerimg;
                Customerimg.sprite = customer_slots.customers[4].customerimg[3];
                break;
        }
        GameManager.Instance.customercrush.value += 0.1f;               //맛없으니 감소 
        maxcustomer += 1;
        customerint += 1;
        //돈주고 나감 
        //돈 이미지 출력
        customercoin.SetActive(true);
        speachImg.SetActive(true);
        RecipeButton.SetActive(false);
        speachtext.text = customer_slots.customers[rndimg].customermanager.cusinfo.customerscript[3];
        yield return new WaitForSeconds(0.8f);
        speachImg.SetActive(false);
        customer_state = Customertaste.CUSTOMERDELICIOUS;
        yield return new WaitForSeconds(4.0f);
        //퇴장
        StartCoroutine(TImeOver());
        yield return null;
     
    }
    //마감할때 리셋하는 함수
    IEnumerator resetcustomerscore()
    {
        //타이머 리셋하는 것도 만들어야함
        timer.min = 209;
        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.BookWindow.SetActive(true);
        GameManager.Instance.BookPanle.SetActive(true);
        GameManager.Instance.scorepanel.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        GameManager.Instance.BookWindow.SetActive(false);
        GameManager.Instance.BookPanle.SetActive(false);
        GameManager.Instance.scorepanel.SetActive(false);
        StartCoroutine(CreateCustomer());
        customerint = 0;
        GameManager.Instance.playermoneymin = 0;
        customerisgo = false;
    }
    //레시피가 없으면 
    IEnumerator nomaterialcutstomereaction()
    {
        speachImg.SetActive(true);
        //맛없는 표정
        switch (rndimg)
        {
            case 0:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[0].customerimg;
                Customerimg.sprite = customer_slots.customers[0].customerimg[2];
                break;
            case 1:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[1].customerimg;
                Customerimg.sprite = customer_slots.customers[1].customerimg[2];
                break;
            case 2:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[2].customerimg;
                Customerimg.sprite = customer_slots.customers[2].customerimg[2];
                break;
            case 3:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[3].customerimg;
                Customerimg.sprite = customer_slots.customers[3].customerimg[2];
                break;
            case 4:
                customer_slots.customers[rndimg].customerimg = customer_slots.customers[4].customerimg;
                Customerimg.sprite = customer_slots.customers[4].customerimg[2];
                break;
        }
        speachtext.text = customer_slots.customers[rndimg].customermanager.cusinfo.customerscript[4];
        yield return new WaitForSeconds(1.0f);
        speachImg.SetActive(false);
        GameManager.Instance.customercrush.value -= 0.1f;               //맛없으니 감소 
        //퇴장
        orderisstart = false;
        customerisgo = false;
        RecipeButton.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        customercollider.enabled = true;
        yield return null;
        //손님 생성
        StartCoroutine(CreateCustomer());
    }

    public void addcustomercoin()
    {
        GameManager.Instance.playermoneymin += all_recipe.recipeinfos[rndimg].recipemanagers.recipeinfo.foodprice;
        GameManager.Instance.playermoneyint += GameManager.Instance.playermoneymin;
        //동전 나오는 소리 
        SoundManager.instance.effectbgm[5].Play();
        customercoin.SetActive(false);
    }
}
