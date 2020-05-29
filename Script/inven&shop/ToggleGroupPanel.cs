using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroupPanel : MonoBehaviour
{
    public GameObject[] InvenPanel;

    private void OnEnable()
    {
        InvenPanel[0].SetActive(true);
    }


    public void DungeonUseButton()
    {
        InvenPanel[0].SetActive(true);
        InvenPanel[1].SetActive(false);
        InvenPanel[2].SetActive(false);

    }

    public void VegetableUseButton()
    {
        InvenPanel[0].SetActive(false);
        InvenPanel[1].SetActive(true);
        InvenPanel[2].SetActive(false);
    }

    public void SpecialUseButton()
    {
        InvenPanel[0].SetActive(false);
        InvenPanel[1].SetActive(false);
        InvenPanel[2].SetActive(true);
    }
}
