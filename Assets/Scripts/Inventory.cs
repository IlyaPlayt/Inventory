using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    [SerializeField] private Text walletText;
    public float wallet;
    
    private void Update()
    {
        walletText.text = wallet.ToString();
    }

    public bool BuyItem(Item item)
    {
        if (item.priсe <= wallet)
        {
            wallet -= item.priсe;
            return true;
        }

        return false;
    }

    public void SellItem(Item item)
    {
        wallet += item.priсe;
    }

    public void PointerEnter()
    {
        Debug.Log("Well come");
    }
    public void PointerExit()
    {
        Debug.Log("Good by");
    }
    
}