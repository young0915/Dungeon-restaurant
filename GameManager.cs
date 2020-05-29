using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//게임 점수 관리

   
public enum GAMEWINDOW
{
    GAMEWINDOW_BEER,
    GAMEWINDOW_INVEN,
    GAMEWINDOW_KINDPLATE,
    GAMEWINDOW_MATERIALCARE,
    GAMEWINDOW_MORTA,
    GAMEWINDOW_PAN,
    GAMEWINDOW_OVEN,
    GAMEWINDOW_POT
}

public class GameManager : MonoBehaviour
{
    //게임 정보
    public enum GameScore
    {
        GAME_TASTE_FOOD = 10,
        GAME_CARE_FOOD = 20,
        GAME_ROASTING_FOOD = 30,
        GAME_NOT_ROASTING_FOOD = 20,
        GAME_BEER_FINISHED = 100
    }
    //GameManager 싱글톤
    #region
    //싱글턴 팬터을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    //인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (_instance == null)
                {
                    Debug.Log("no SingleTon");
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    /// <summary>
    /// Gamemanager  변수들
    /// </summary>
    #region
    public GAMEWINDOW game_window;
    public GameScore game_score;
    public CustomerMove customer_move;
    public Text playermoney;                                                         //플레이어가 관리하는 돈
    public int playermoneyint;                                                                //플레이어 돈
    public int playermoneymin;
    public int playerscore=0;
    public GameObject cookingaLLwindow;                                     //최종쿠킹메인창,  쿠킹하는 창을 키려면 먼저 켜줘야함
    public GameObject cookingzone;                                              //쿠킹존,  접시 담기, 재료, 칼썰기, 절구통, 굽기,끓이기, 오븐

    public GameObject invenwindow;                                             //재료 담는 창
    public GameObject mortaclickpanel;                                         //절구
    public GameObject materialcarepanel;                                      //재료손질
    public GameObject knifeobj;
    public GameObject bearcookingwindow;
    public GameObject pancookingwindow;
    public GameObject ovencookingwindow;
    public GameObject potcookingwindow;
    public GameObject platedecowindow;
    public GameObject finishedfoodwindow;
    public GameObject yumyummousepanel;
 
    public GameObject questallwindow;                                          //퀘스트 
    public GameObject CouponWindow;
    public GameObject couponlottoImg;
    public GameObject GardenWindow;
    public GameObject bearcupfinshed;                                                  //맥주 나갔다는 것을 알려주기 위한 것      
    public GameObject RecipeWindow;                                                   //레시피
    public GameObject BookPanle;
    public GameObject BookWindow;
    public GameObject orderwindow;
    public GameObject customerinfobtn;
    public GameObject customerinfowindow;
    public GameObject dispanel;
    public GameObject dishfrontpanel;
    public GameObject sourcepanel;
    public GameObject oventoggle;

    public GameObject sourcebgtoggle;
    public GameObject dishbgtoggle;
    public GameObject toggleobj;                                                   //토글 이미지

    public Score score;
    public GameObject scorepanel;
    public Toggle anitoggle;
    public Slider customercrush;                                                     //호감 측정
    public BoxCollider2D toolcol;                                                       //주방에 사용하는 콜라이더
    private BoxCollider2D trashcol;
    public Button bowlbutton;
    public Button platebutton;
    public GameObject dishtyepeone;
    public GameObject traymove;
    public GameObject dishtyepetwo;
    public PlateDecoCooking plate_decocook;
    public Button iconbowl;
    public Button basketbutton;
    public bool issetting;                                                                  //셋팅중인가
    public bool iseatsetting;                                                              //셋팅하면서 음식이 나갈 경우
    public GameObject[] soupimg;
    public GameObject[] soupsprite;
    public BasketSlot basket_slot;
    private void OnEnable()
    {
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        iseatsetting = false;
        issetting = false;
       toolcol = GameObject.Find("toolcollider").GetComponent<BoxCollider2D>();
        toolcol.enabled = false;
        trashcol = GameObject.Find("trashcollider").GetComponent<BoxCollider2D>();
        trashcol.enabled = false;
    }
#endregion

    private void FixedUpdate()
    {
        playermoney.text = playermoneyint.ToString();
        if (playermoneyint <= 0)
        {
            playermoneyint = 0;
        }
         if(dishtyepetwo.activeSelf == true)
        {
            
            dishtyepetwo.transform.position = new Vector2(traymove.transform.position.x, traymove.transform.position.y);
        }
         if(dishtyepeone.activeSelf == true)
        {
            dishtyepeone.transform.position = new Vector2(traymove.transform.position.x, traymove.transform.position.y);
        }
    
    }

    //최종쿠킹메인창
    public void CloseAllCookingWindow()
    {
        cookingaLLwindow.SetActive(false);
        cookingzone.SetActive(false);
        customerinfobtn.SetActive(true);
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        switch (game_window)
        {
            case GAMEWINDOW.GAMEWINDOW_BEER:
                bearcookingwindow.SetActive(false);
               
                break;
            case GAMEWINDOW.GAMEWINDOW_INVEN:
                invenwindow.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_KINDPLATE:
                cookingzone.SetActive(false);
                cookingaLLwindow.SetActive(false);
                sourcebgtoggle.SetActive(false);
                toggleobj.SetActive(false);
                platedecowindow.SetActive(false);
                dishbgtoggle.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_MATERIALCARE:
                knifeobj.SetActive(false);
                materialcarepanel.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_MORTA:
                mortaclickpanel.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_PAN:
                sourcebgtoggle.SetActive(false);
                toggleobj.SetActive(false);
                SoundManager.instance.effectbgm[4].Stop();
                pancookingwindow.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_OVEN:
                sourcebgtoggle.SetActive(false);
                toggleobj.SetActive(false);
                SoundManager.instance.effectbgm[4].Stop();
                ovencookingwindow.SetActive(false);
                oventoggle.SetActive(false);
                break;
            case GAMEWINDOW.GAMEWINDOW_POT:
                sourcebgtoggle.SetActive(false);
                toggleobj.SetActive(false);
                // SoundManager.instance.effectbgm[3].Stop();
                potcookingwindow.SetActive(false);
                break;
        }
    }
    //쿠폰 오픈창
    public void OpenCouponWindowButton()
    {
        CouponWindow.SetActive(true);
        couponlottoImg.SetActive(true);
        customerinfobtn.SetActive(false);
    }
    //쿠폰 클로우즈
    public void CLoseCouponWindowButton()
    {
        CouponWindow.SetActive(false);
        couponlottoImg.SetActive(false);
    }
    //Hp맥주포션 오픈창 
    public void OpenBearWindow()
    {
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        bearcookingwindow.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_BEER;
        customerinfobtn.SetActive(false);

    }
    //옵션 오픈창
    //퀘스트 오픈창 
    public void OpenQuestAllWindow()
    {
        questallwindow.SetActive(true);
        customerinfobtn.SetActive(false);

    }
    //퀘스트 닫기 
    public void CloseQuestAllWindow()
    {
        questallwindow.SetActive(false);
    }
    //정원 창 -> 채소 심기 등
    public void OpenGardenWindow()
    {
        GardenWindow.SetActive(true);
        customerinfobtn.SetActive(false);
    }
    //정원 꺼짐 -> 채소 심기 등
    public void CloseGardenWindow()
    {
        GardenWindow.SetActive(false);
    }
    //재료 창 열림
    public void OpenInvenWindow()
    {
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        invenwindow.SetActive(true);
        customerinfobtn.SetActive(false);
        game_window = GAMEWINDOW.GAMEWINDOW_INVEN;
    }
    //술이 끝났을 때 다 따랐을 경우 보내도록 처리한다
    public void FinshedGoBear()
    {
        cookingaLLwindow.SetActive(false);
        cookingzone.SetActive(false);
        bearcookingwindow.SetActive(false);
        bearcupfinshed.SetActive(true);
    }
    //절구통 오픈칭
    public void OpenMortaWindow()
    {
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        mortaclickpanel.SetActive(true);
        customerinfobtn.SetActive(false);

        game_window = GAMEWINDOW.GAMEWINDOW_MORTA;
    }
    //손질
    public void OpenMaterialCutWindow()
    {
        knifeobj.SetActive(true);
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        materialcarepanel.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_MATERIALCARE;
        customerinfobtn.SetActive(false);
    }
    public void OpenRecipeWindow()
    {
        BookPanle.SetActive(true);
        BookWindow.SetActive(true);
        RecipeWindow.SetActive(true);
        customerinfobtn.SetActive(false);

    }
    public void CloseRecipeWindow()
    {
        BookPanle.SetActive(false);
        BookWindow.SetActive(false);
        RecipeWindow.SetActive(false);
        customerinfobtn.SetActive(true);
    }
    //후라이펜
    public void OpenPanWidnow()
    {
        toggleobj.SetActive(true);
        sourcebgtoggle.SetActive(true);
        SoundManager.instance.effectbgm[4].Play();
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        pancookingwindow.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_PAN;
        sourcepanel.SetActive(true);
    }
    //냄비
    public void OpenPotWindow()
    {
        toggleobj.SetActive(true);
        sourcebgtoggle.SetActive(true);
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        sourcepanel.SetActive(true);
        potcookingwindow.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_POT;
        customerinfobtn.SetActive(false);

    }
    //오븐
    public void OpenovenWindow()
    {
        oventoggle.SetActive(true);
        toggleobj.SetActive(true);
        sourcebgtoggle.SetActive(true);
        SoundManager.instance.effectbgm[4].Play();
        cookingaLLwindow.SetActive(true);
        cookingzone.SetActive(true);
        sourcepanel.SetActive(true);
        ovencookingwindow.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_OVEN;
        customerinfobtn.SetActive(false);

    }
    //주문서 
    public void openorderwindow()
    {
        orderwindow.SetActive(true);
        StartCoroutine(closeorderwindows());
        customerinfobtn.SetActive(false);

    }
    //고객 정보 인포
    public void opencustomerinfowindow()
    {
        customerinfowindow.SetActive(true);
        StartCoroutine(closecustomerwindow());
        customerinfobtn.SetActive(false);

    }
    public void openplatedecoWindow()
    {
        toolcol.enabled = true;
        if (plate_decocook.bowlimg.activeSelf == true)
        {
            if (basket_slot.isstart)
            {
                soupsprite[0].SetActive(false);
                soupsprite[1].SetActive(true);
            }
            else
            {
                soupsprite[0].SetActive(true);
                soupsprite[1].SetActive(false);
            }
        }
        else
        {
            soupimg[0].SetActive(false);
            soupimg[1].SetActive(false);
            soupsprite[0].SetActive(false);
            soupsprite[1].SetActive(false);
        }

        if (dishtyepeone.activeSelf == true)
        {
            if (basket_slot.isstart)
            {
             //   soupsprite[0].transform.position = new Vector2(dishtyepeone.transform.position.x, dishtyepeone.transform.position.y);
            }
            else
            {
               // soupsprite[1].transform.position = new Vector2(dishtyepeone.transform.position.x, dishtyepeone.transform.position.y);
            //    soupsprite[0].SetActive(true);
             //   soupsprite[1].SetActive(false);
            }
        }
        else
        {
            soupsprite[0].SetActive(false);
            soupsprite[1].SetActive(false);
        }
      
        dishtyepeone.transform.position = new Vector2(0, 7);
        dishtyepetwo.transform.position = new Vector2(0, 7);
        sourcebgtoggle.SetActive(true);
        cookingaLLwindow.SetActive(true);
        platedecowindow.SetActive(true);
        game_window = GAMEWINDOW.GAMEWINDOW_KINDPLATE;
    }

    public void Finishedfood()
    {
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        if (basket_slot.isstart)
        {
            soupsprite[0].transform.position = new Vector2(dishtyepeone.transform.position.x, dishtyepeone.transform.position.y);

        }
        else
        {
            soupsprite[1].transform.position = new Vector2(dishtyepeone.transform.position.x, dishtyepeone.transform.position.y);
        }

        if (plate_decocook.plateimg.activeSelf == true)
        {
            dishtyepeone.SetActive(false);
            dishtyepetwo.SetActive(true);
        }
        if(plate_decocook.bowlimg.activeSelf ==true)
        {
            dishtyepeone.SetActive(true);
            dishtyepetwo.SetActive(false);
        }
        SoundManager.instance.effectbgm[6].Play();
        sourcebgtoggle.SetActive(false);
        finishedfoodwindow.SetActive(true);
        toggleobj.SetActive(false);
        if (anitoggle.isOn)
        {
            StartCoroutine(CustomerYumYum());
            iseatsetting = true;
        }
        else
        {
            StartCoroutine(nocustomerYumyum());
        }
    
    }
    public void pickdownbasket()
    {
        toolcol.enabled = true;
    }
    public void pickdownbasketunlock()
    {
        Debug.Log("해제  toolcol.enabled : " + toolcol.enabled);
        toolcol.enabled = false;
        issetting = true;
    }
    public void pickdowntrash()
    {
        trashcol.enabled = true;
    }
    //고객정보 인포창
    IEnumerator closecustomerwindow()
    {
        yield return new WaitForSeconds(1.2f);
        customerinfowindow.SetActive(false);
    }
   //주문서 다음
    IEnumerator closeorderwindows()
    {
        yield return new WaitForSeconds(3.0f);
        orderwindow.SetActive(false);
    }
    /// <summary>
    /// 다시한번 확인할 것
    /// </summary>
    /// <returns></returns>
    //음식 나오는 애니메이션
     IEnumerator CustomerYumYum()
    {
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        soupsprite[0].SetActive(false);
        soupsprite[1].SetActive(false);
        iseatsetting = true;
        yield return new WaitForSeconds(6.0f);
        finishedfoodwindow.SetActive(false);
        SoundManager.instance.effectbgm[7].Play();
        yumyummousepanel.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        yumyummousepanel.SetActive(false);
        cookingaLLwindow.SetActive(false);
        cookingzone.SetActive(false);
        customerinfobtn.SetActive(true);
        dishbgtoggle.SetActive(false);
        platedecowindow.SetActive(false);
        game_window = GAMEWINDOW.GAMEWINDOW_KINDPLATE;
        dishbgtoggle.SetActive(false);
        platedecowindow.SetActive(false);
        bearcupfinshed.SetActive(false);
        SoundManager.instance.effectbgm[7].Stop();
        
        //점수 합산해서 상태 패턴 알고리즘 넣기
        if (playerscore>= 80)
        {
            customer_move.foodjudgment(CustomerMove.Customertaste.CUSTOMERDELICIOUS);
        }
        else
        {
            customer_move.foodjudgment(CustomerMove.Customertaste.CUSTOMERNOTDELICIOUS);
        }
        dishtyepeone.SetActive(false);
        dishtyepetwo.SetActive(false);
    }
    IEnumerator nocustomerYumyum()
    {
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        soupimg[0].SetActive(false);
        soupimg[1].SetActive(false);
        iseatsetting = true;
        sourcebgtoggle.SetActive(false);
        finishedfoodwindow.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        sourcebgtoggle.SetActive(false);
        cookingaLLwindow.SetActive(false);
        cookingzone.SetActive(false);
        customerinfobtn.SetActive(true);
        dishbgtoggle.SetActive(false);
        platedecowindow.SetActive(false);
        game_window = GAMEWINDOW.GAMEWINDOW_KINDPLATE;
        dishbgtoggle.SetActive(false);
        platedecowindow.SetActive(false);
        bearcupfinshed.SetActive(false);
        //점수 합산해서 상태 패턴 알고리즘 넣기
        if (playerscore>= 80)
        {
            customer_move.foodjudgment(CustomerMove.Customertaste.CUSTOMERNOTDELICIOUS);
        }
        else
        {
            customer_move.foodjudgment(CustomerMove.Customertaste.CUSTOMERDELICIOUS);
        }
        dishtyepeone.SetActive(false);
        dishtyepetwo.SetActive(false);

    }
}
