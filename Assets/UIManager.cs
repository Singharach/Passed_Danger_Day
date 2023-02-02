using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public EquipmentWindowUI equipmentWindowUI;

    [Header("UI Window")] //create a header in a script
    public GameObject hudWindow;
    public GameObject selectWindow;
    public GameObject equipmentScreenWindow;
    public GameObject weaponInventoryWindow;

    [Header("Equipment Window Slot Selected")]
    public bool rightHandSlot01Selected;
    public bool rightHandSlot02Selected;
    public bool leftHandSlot01Selected;
    public bool leftHandSlot02Selected;

    [Header("Weapon Inventory")]
    public GameObject weaponInventorySlotPrefab;
    public Transform weaponInventorySlotsParent;
    WeaponInventorySlot[] weaponInventorySlots;

    private void Awake()
    {
        equipmentWindowUI = FindObjectOfType<EquipmentWindowUI>(); //find object of type EquipmentWindowUI in the current scene
    }

    private void Start()
    {
        weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>(); //gets all of the components of type WeaponInventorySlot that are children of the weaponInventorySlotsParent object
        equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory); //loads the weapons from the player's inventory onto the equipment window user interface
    }

    public void UpdateUI()
    {
        #region Weapon Inventory Slots
        for (int i = 0; i < weaponInventorySlots.Length; i++)
        {
            if (i < playerInventory.weaponInventory.Count)
            {
                if (weaponInventorySlots.Length < playerInventory.weaponInventory.Count)
                {
                    Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);//creates an instance and attaches it to the weaponInventorySlotsParent game object
                    weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>(); //retrieves all and stores them in an array called weaponInventorySlots
                }
                weaponInventorySlots[i].AddItem(playerInventory.weaponInventory[i]); //adds an item from the player's weapon inventory to a weapon inventory slot
            }
            else
            {
                weaponInventorySlots[i].ClearInventorySlot(); //clears the inventory slot at the index i in the weaponInventorySlots array
            }
        }

        #endregion
    }

    public void OpenSelectWindow()
    {
        selectWindow.SetActive(true);
    }

    public void CloesSelectWindow()
    {
        selectWindow.SetActive(false);
    }

    public void CloseAllInventoryWindow()
    {
        RestAllSelectedSlots();
        weaponInventoryWindow.SetActive(false);
        equipmentScreenWindow.SetActive(false);
    }

    public void RestAllSelectedSlots()
    {
        rightHandSlot01Selected = false;
        rightHandSlot02Selected = false;
        leftHandSlot01Selected = false;
        leftHandSlot02Selected = false;
    }
}
}
