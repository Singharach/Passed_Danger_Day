using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        public WeaponItem unarmedWeapon;

        public WeaponItem[] weaponInRightHandSlots = new WeaponItem[1]; //creates an array of WeaponItem objects called weaponInRightHandSlots with a size
        public WeaponItem[] weaponInLeftHandSlots = new WeaponItem[1];

        public int currentRightWeaponIndex = -1; //Default
        public int currentLeftWeaponIndex = -1;

        public List<WeaponItem> weaponInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>(); //get the WeaponSlotManager component from the children of the current object

        }

        private void Start()
        {
            rightWeapon = weaponInRightHandSlots[0];
            leftWeapon = weaponInLeftHandSlots[0];
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }

        public void ChangeRightWeapon() //LoadWeapon To Hand 
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1; //increases value 1

            if (currentRightWeaponIndex == 0 && weaponInRightHandSlots[0] != null)
            {
                rightWeapon = weaponInRightHandSlots[currentRightWeaponIndex]; //assigns the variable rightWeapon to the value of the element in the array
                weaponSlotManager.LoadWeaponOnSlot(weaponInRightHandSlots[currentRightWeaponIndex], false); //calling the LoadWeaponOnSlot function from the weaponSlotManager object
            }
            else if (currentRightWeaponIndex == 0 && weaponInRightHandSlots[0] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }
            else if (currentRightWeaponIndex == 1 && weaponInRightHandSlots[1] != null)
            {
                rightWeapon = weaponInRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponInRightHandSlots[currentRightWeaponIndex], false);
            }
            else if (currentRightWeaponIndex  == 1 && weaponInRightHandSlots[1] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;

            }

            if (currentRightWeaponIndex > weaponInRightHandSlots.Length - 1) //if Change Load unarmed
            {
                currentRightWeaponIndex = -1; //no current right weapon
                rightWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, false); //calling the LoadWeaponOnSlot() function from the weaponSlotManager object
            }

        }

        public void ChangeLeftWeapon()
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;

            if (currentLeftWeaponIndex == 0 && weaponInLeftHandSlots[0] != null)
            {
                leftWeapon = weaponInLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponInLeftHandSlots[currentLeftWeaponIndex], false);
            }
            else if (currentLeftWeaponIndex == 0 && weaponInLeftHandSlots[0] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }

            else if (currentLeftWeaponIndex == 1 && weaponInLeftHandSlots[1] != null)
            {
                leftWeapon = weaponInLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponInLeftHandSlots[currentLeftWeaponIndex], false);
            }
            else if (currentLeftWeaponIndex  == 1 && weaponInLeftHandSlots[1] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex +1;

            }

            if (currentLeftWeaponIndex > weaponInLeftHandSlots.Length - 1)
            {
                currentLeftWeaponIndex = -1;
                leftWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, false);
            }
        }
    }
}