using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//IEndDragHandler ->손을 때면 불리는 것


public class pushSultong : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public AudioSource Sulpushsound;
    public GameObject SulOutCup;                                //술통에서 술떨어지는 이미지
    public GameObject SulInCup;                                 //컵에서 술이 담기는 이미지         
    public bool push = false;
    private float pusingBear;
    private RectTransform rectTransForm;
    private void OnEnable()
    {
        SulOutCup.SetActive(false);
        SulInCup.SetActive(false);
        rectTransForm = GetComponent<RectTransform>();
        Sulpushsound.Stop();
    }
    //IPointerDownHandler ,IBeginDragHandler 들어있음
    #region
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    #endregion

    //들고 내림 -> 원상태로 돌려 놓을 것
    public void OnEndDrag(PointerEventData eventData)
    {
        push = false;
        //손을 놓았더라면 
        if (!push)
        {
            //위치 잡고
            rectTransForm.position = new Vector2(-3.7f, -0.5f);
            //애니메이션 이팩트 나오고
            SulOutCup.SetActive(false);
            //소리도 나오고
            Sulpushsound.Stop();
           // pusingBear = 0; //활성할 때마다 0으로 처리
        }
    }

    //들고있는중
    public void OnDrag(PointerEventData eventData)
    {
        push = true;
        pusingBear += Time.deltaTime;
     
        rectTransForm.anchoredPosition += eventData.delta;
        if (push)
        {
            SulOutCup.SetActive(true);
            Sulpushsound.Play();
    //        Debug.Log("sul sec : " + pusingBear);
            if (pusingBear >= 0.8f)
            {
                SulInCup.SetActive(true);               //술이 넘치는 애니메이션 처리
                GameManager.Instance.playerscore += (int)GameManager.GameScore.GAME_BEER_FINISHED;
            }
        }
    }
}
