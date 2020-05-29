using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Customerslots : MonoBehaviour
{
    public List<CustomerInfo> customers;
} 
[System.Serializable]
public class CustomerInfo
{
    public Sprite[] customerimg;
    public CustomerManager customermanager;
}