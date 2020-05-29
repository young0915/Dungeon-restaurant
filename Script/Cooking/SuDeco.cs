using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuDeco : MonoBehaviour
{
    public GameObject SulDeco;
    public void OnEnable()
    {
        SulDeco.SetActive(false);
    }

    public void SulDecoButton()
    {
        SulDeco.SetActive(true);
    }
}
