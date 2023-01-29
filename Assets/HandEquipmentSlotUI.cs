using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
public class HandEquipmentSlotUI : MonoBehaviour
{
    public Image icon;
    WeaponItem weapon;

    public bool rightHandSlot01;
    public bool rightHandSlot02;
    public bool leftHandSlot01;
    public bool leftHandSlot02;

    public void AddItem(WeaponItem newWeapon)
    {
        weapon = newWeapon;
        icon.sprite = weapon.itemIcon; //assigns value itemIcon weapon object to the sprite 
        icon.enabled = true; //sets enabled icon object to true
        gameObject.SetActive(true); //sets the gameObject to active
    }

    public void ClearItem()
    {
        weapon = null;
        icon.sprite = null; //sets the sprite of the icon object to null
        icon.enabled = false; //sets the enabled icon object to false
        gameObject.SetActive(false); //sets the active state of a game object to false
    }
}
}
