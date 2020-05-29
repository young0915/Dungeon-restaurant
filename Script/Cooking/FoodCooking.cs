using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCooking : MonoBehaviour
{
    public enum ITEMMATERIAL
    {
        COCKOACH_MATERIAL,
       FISH,
       EMPTY
    }

    public ITEMMATERIAL itemtype;
    public float cooktime;
    int liecooktime;
    public bool cookstart;
    public SpriteRenderer item_spriterender;
    public SpriteRenderer[] soup_spriterender;
    public BasketSlot bakset_slot;
    Vector2 mouseposition;
    Camera Camera;
   public Rigidbody2D rigidbody2d;

    private void OnEnable()
    {
        cooktime = 0.0f;
        cookstart = false;
    }
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
         item_spriterender = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (cookstart)
        {
            cooktime += Time.deltaTime;
            liecooktime = Mathf.RoundToInt(cooktime);
            if (liecooktime >= 5)
            {
                item_spriterender.color = new Color(255, 127, 0);
                if (GameManager.Instance.potcookingwindow.activeSelf == true)
                {
                    if (bakset_slot.basket_item == BasketSlot.BASITEMSTATE.DUNGEON_BASITEM_COCKROCH)
                    {
                        itemtype = ITEMMATERIAL.COCKOACH_MATERIAL;
                        for (int i = 0; i < soup_spriterender.Length; i++)
                        {
                            soup_spriterender[i].enabled = true;
                            soup_spriterender[i].color = new Color(243, 0, 255);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < soup_spriterender.Length; i++)
                        {
                            itemtype = ITEMMATERIAL.FISH;
                            soup_spriterender[i].enabled = true;
                            soup_spriterender[i].color = new Color(215, 178, 87);
                        }
                    }
                }
                GameManager.Instance.playerscore += (int)GameManager.GameScore.GAME_ROASTING_FOOD;
            }
            if (liecooktime >= 15)
            {
                item_spriterender.color = new Color(255, 0, 255, 1);
                GameManager.Instance.playerscore -= (int)GameManager.GameScore.GAME_NOT_ROASTING_FOOD;
            }
        }
        //(조건) 먹는 애니메이션이 떴을 때 그때 사라지게 하기 
        if(GameManager.Instance.yumyummousepanel.activeSelf == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "roasting")
        {
            cookstart = true;
        }
    }

}
