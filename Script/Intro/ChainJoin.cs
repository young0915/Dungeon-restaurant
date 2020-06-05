using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainJoin : MonoBehaviour
{
    public Rigidbody2D Hook;                                                                                            //걸이
    public GameObject LinkPrefab;                                                                                   //체인(덜렁덜렁) 넣을 곳
    int Link;                                                                                                                             //체인 수 
    public SignPanelWeight singpanel;                                                                               //체인과 연결할 사인패널 

    // Start is called before the first frame update
    void Start()
    {
        Link = 1;
        CreateChain();
    }

    void CreateChain()
    {
        Rigidbody2D rb = Hook;                                                                                              //걸이를 Rigidbody에 대입한다.
        //체인 복제
        for (int i = 0; i<Link; i++)
        {
            GameObject link = Instantiate(LinkPrefab, transform);
            HingeJoint2D join = link.GetComponent<HingeJoint2D>();
            join.connectedBody = rb;                                                                                    //Hook의 rigidbody를 해당 joint 함
            if(i<Link-1)
            {
                 rb = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                singpanel.ConnetedBody(link.GetComponent<Rigidbody2D>());
            }
        }

    }

}
