using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
public class WeaponInventorySlot : MonoBehaviour
{
    public Image icon;
    WeaponItem item;

    public void AddItem(WeaponItem newItem) //AddItem that takes in one parameter WeaponItem
    {
        item = newItem;
        icon.sprite = item.itemIcon; //sets sprite icon object to itemIcon
        icon.enabled = true; //sets enabled of icon object to true
        gameObject.SetActive(true); //sets active state of the game object to true
    }

    public void ClearInventorySlot()
    {
        item = null;
        icon.sprite = null; //sets sprite of icon object to null
        icon.enabled = false; //sets enabled of icon object to false
        gameObject.SetActive(false); //sets active state of a game object to false
    }
}
}
