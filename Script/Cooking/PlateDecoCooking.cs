using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateDecoCooking : MonoBehaviour
{
    public GameObject plateimg;
    public GameObject bowlimg;
    public GameObject basket_patekind;

    private void OnEnable()
    {
        basket_patekind.SetActive(true);
        plateimg.SetActive(true);
    }

    public void openplatebutton()
    {
        plateimg.SetActive(true);
        bowlimg.SetActive(false);
    }

    public void openbowlbutton()
    {
        plateimg.SetActive(false);
        bowlimg.SetActive(true);
    }



}
