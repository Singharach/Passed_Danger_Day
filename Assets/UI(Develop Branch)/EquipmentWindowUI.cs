using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
public class EquipmentWindowUI : MonoBehaviour
{
    public bool rightHandSlot01Selected;
    public bool rightHandSlot02Selected;
    public bool leftHandSlot01Selected;
    public bool leftHandSlot02Selected;

    public HandEquipmentSlotUI[] handEquipmentSlotUI; //declares an array of HandEquipmentSlotUI objects

    private void Start()
    {
 
    }

    public void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory)
    {
        for (int i = 0; 1 < handEquipmentSlotUI.Length; i++)
        {
            if (handEquipmentSlotUI[i].rightHandSlot01) //checking if array at index i is true
            {
                handEquipmentSlotUI[i].AddItem(playerInventory.weaponInRightHandSlots[0]); //adds an item from the playerInventory
            }
            else if (handEquipmentSlotUI[i].rightHandSlot02)
            {
                handEquipmentSlotUI[i].AddItem(playerInventory.weaponInRightHandSlots[1]); //adds an item from the playerInventory
            }
            else if (handEquipmentSlotUI[i].leftHandSlot01)
            {
                handEquipmentSlotUI[i].AddItem(playerInventory.weaponInLeftHandSlots[0]);
            }
            else
            {
                handEquipmentSlotUI[i].AddItem(playerInventory.weaponInLeftHandSlots[1]);
            }
        }
    }

    public void SelectRightHandSlot01()
    {
        rightHandSlot01Selected = true; //sets to true
    }

    public void SelectRightHandSlot02()
    {
        rightHandSlot01Selected = true;
    }

    public void SelectLeftHandSlot01()
    {
        leftHandSlot01Selected = true;
    }

    public void SelectLeftHandSlot02()
    {
        leftHandSlot02Selected = true;
    }
}
}
