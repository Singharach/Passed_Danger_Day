using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
public class QuickSlotUI : MonoBehaviour
{
    public Image leftWeaponIcon;
    public Image rightWeaponIcon;

    public void UpdateWeaponQuickSlot(bool isLeft, WeaponItem weapon)
    {
        if(isLeft == false)
        {
            if(weapon.itemIcon != null)
            {
            rightWeaponIcon.sprite = weapon.itemIcon; //sets sprite rightWeaponIcon object to the itemIcon of the weapon object
            rightWeaponIcon.enabled = true; // sets enabled rightWeaponIcon to true
            }
            else
            {
                rightWeaponIcon.sprite = null;
                rightWeaponIcon.enabled = false;
            }

        }
        else
        {
            if(weapon.itemIcon != null)
            {
            leftWeaponIcon.sprite = weapon.itemIcon;
            leftWeaponIcon.enabled = true;
            }
            else
            {
                leftWeaponIcon.sprite = null;
                leftWeaponIcon.enabled = false;
            }

        }

    }

}
}
