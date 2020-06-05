using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사인 패널 드는 곳
public class SignPanelWeight : MonoBehaviour
{
    public float endditance = 0.6f;
    public void ConnetedBody(Rigidbody2D Endbody)
    {
        HingeJoint2D join = gameObject.AddComponent<HingeJoint2D>();
        join.autoConfigureConnectedAnchor = false;
        join.connectedBody = Endbody;                                                                                                    //사인패널은 마지막 물리수
        join.anchor = Vector2.zero;
        join.connectedAnchor = new Vector2(0f, endditance);
    }

}
