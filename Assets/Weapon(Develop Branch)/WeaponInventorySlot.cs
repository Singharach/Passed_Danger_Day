using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
public class WeaponInventorySlot : MonoBehaviour
{
    PlayerInventory playerInventory;
    WeaponSlotManager weaponSlotManager;
    UIManager uiManager;
    public Image icon;
    WeaponItem item;

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

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

    public void EquipThisItem()
    {
        //Remove current item
        //Add current item to inventory
        //Equip this new item
        //Remove this item from inventory

        if (uiManager.rightHandSlot01Selected)
        {
            playerInventory.weaponInventory.Add(playerInventory.weaponInRightHandSlots[0]);
            playerInventory.weaponInRightHandSlots[0] = item;
            playerInventory.weaponInventory.Remove(item);

        }
        else if (uiManager.rightHandSlot02Selected)
        {
            playerInventory.weaponInventory.Add(playerInventory.weaponInRightHandSlots[1]);
            playerInventory.weaponInRightHandSlots[1] = item;
            playerInventory.weaponInventory.Remove(item);

        }
        else if (uiManager.leftHandSlot01Selected)
        {
            playerInventory.weaponInventory.Add(playerInventory.weaponInLeftHandSlots[0]);
            playerInventory.weaponInLeftHandSlots[0] = item;
            playerInventory.weaponInventory.Remove(item);
        }
        else if (uiManager.leftHandSlot02Selected)
        {
            playerInventory.weaponInventory.Add(playerInventory.weaponInLeftHandSlots[1]);
            playerInventory.weaponInLeftHandSlots[1] = item;
            playerInventory.weaponInventory.Remove(item);
        }
        else
        {
            return;
        }

        playerInventory.rightWeapon = playerInventory.weaponInRightHandSlots[playerInventory.currentRightWeaponIndex];
        playerInventory.leftWeapon = playerInventory.weaponInLeftHandSlots[playerInventory.currentLeftWeaponIndex];

        weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
        weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, true);

        uiManager.equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);
        uiManager.RestAllSelectedSlots();

    }
}
}
