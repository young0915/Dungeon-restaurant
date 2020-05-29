using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDownBasket : MonoBehaviour
{
    public BasketInventory basket_inven;
    public bool iscutting;
    Vector2 mouseposition;
    Camera Camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //주방기구에 닿았을 때 
        if (collision.tag.Equals("tool"))
        {
            iscutting = true;
        }
        if (collision.tag.Equals("trash"))
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        iscutting = true;
    }
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.toolcol.enabled == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.position = new Vector2(basket_inven.Basketslots[0].transform.position.x, basket_inven.Basketslots[0].transform.position.y);
            gameObject.transform.localScale = Vector2.one * 2;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.position = Vector2.zero;
            gameObject.transform.localScale = Vector2.one * 5;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (GameManager.Instance.iseatsetting == true)
            {
                gameObject.transform.localScale = Vector2.one * 5;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.transform.position = new Vector2(GameManager.Instance.traymove.transform.position.x, GameManager.Instance.traymove.transform.position.y);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
            }
        }
        if (GameManager.Instance.yumyummousepanel.activeSelf == true)
        {
            Destroy(gameObject);
        }
    }
  


}
