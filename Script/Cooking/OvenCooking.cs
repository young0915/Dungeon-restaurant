using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OvenCooking : MonoBehaviour
{
    public GameObject oventool;
   public float distanceup = -4;
    public bool isstop;
    public bool isdown;
    public Toggle oventoggle;
    public float speed = 1;

    private void OnEnable()
    {
        oventool.transform.position = new Vector2(oventool.transform.position.x, -2);
    }
    private void FixedUpdate()
    {
        #region
        if (!oventoggle.isOn)
        {
            oventool.transform.Translate(Vector2.down * speed * Time.deltaTime);
            SoundManager.instance.effectbgm[4].Stop();
        }
        else
        {
            oventool.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        #endregion
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "upwall")
        {
            speed = 0;
        }
        if (collision.tag == "downwall")
        {
            speed = 0;
        }

    }
}
