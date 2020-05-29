using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPickMe : MonoBehaviour
{
    public Text[] rndtext;
    public GameObject[] rndimg;
    public ItemSlot item_slot;
    public int rnd_item;

    private void Start()
    {
        rnd_item = Random.Range(0, 3);
        switch (rnd_item)
        {
            //꽝
            case 0:
                rndtext[0].text = "꽝";
                rndtext[1].enabled = false;
                rndtext[2].enabled = false;
                rndimg[0].SetActive(false);
                rndimg[1].SetActive(false);
                break;
            //바퀴벌레
            case 1:
                item_slot.itemCout += 5;
                rndtext[0].enabled = false;
                rndtext[1].text = "바퀴벌레 5개";
                rndtext[2].enabled =false;
                rndimg[0].SetActive(true);
                rndimg[1].SetActive(false);
                break;
            //코인
            case 2:
                GameManager.Instance.playermoneyint += 500;
                rndtext[0].enabled = false;
                rndtext[1].enabled = false;
                rndtext[2].text = "500 코인";
                rndimg[0].SetActive(false);
                rndimg[1].SetActive(true);
                break;
        }
    }
}
