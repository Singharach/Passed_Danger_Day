using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        public WeaponItem attackingWeapon;
        WeaponHolderSlot leftHandSlot; //of type
        WeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        Animator animator; //refactored to create an instance of the Animator class and assign it to the animator variable

        QuickSlotUI quickSlotUI; //creates a new instance of the QuickSlotUI class called quickSlotUI.

        PlayerStats playerStats;

        private void Awake()
        {
            animator = GetComponent<Animator>(); //get the Animator component from a game object
            quickSlotUI = FindObjectOfType<QuickSlotUI>(); //finds the QuickSlotUI object in the scene and assigns it to the variable quickSlotUI
            playerStats = GetComponentInParent<PlayerStats>();


            WeaponHolderSlot[] weaponHolderSlot = GetComponentsInChildren<WeaponHolderSlot>(); //creates an array of WeaponHolderSlot objects called weaponHolderSlot
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlot) //looping an array of WeaponHolderSlot objects called weaponHolderSlot and assigning each element to the variable weaponSlot
            {
                if (weaponSlot.isLeftHandSlot) //check left
                {
                    leftHandSlot = weaponSlot; //assigns value of variable weaponSlot to the variable leftHandSlot
                }
                else if (weaponSlot.isRightHandSlot) //check right
                {
                    rightHandSlot = weaponSlot;
                }

            }
        }
        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem); //function that loads a weapon model into the left hand slot of the character
                LoadLeftWeaponDamageCollider();
                quickSlotUI.UpdateWeaponQuickSlot(true, weaponItem); //updates the weapon quick slot UI with a given weapon item

                #region  Handle Left Weapon Idel Animations
                if(weaponItem != null)
                {
                    animator.CrossFade(weaponItem.left_hand_idle, 0.2f); //used to animate a character in a game 
                }           //CrossFade animator object to transition from the current animation state to the left_hand_idle
                else
                {
                    animator.CrossFade("Left Arm Empty", 0.2f); //animation to crossfade from the current animation to the animation named "Left Arm Empty"
                }
                #endregion
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                quickSlotUI.UpdateWeaponQuickSlot(false, weaponItem);                
                
                #region  Handle Right Weapon Idel Animations
                if(weaponItem != null)
                {
                    animator.CrossFade(weaponItem.right_hand_idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Right Arm Empty", 0.2f);
                }
                #endregion
            }
        }

        #region Handle Weapon's Damage Collider
        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }

        public void OpenLeftDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();
        }

        public void CloseRightDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }

        public void CloseLeftDamageCollider()
        {
            leftHandDamageCollider.DisableDamageCollider();
        }
        #endregion

        #region Handle Weapon's Stamina Drainage
        public void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }

        public void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }
        #endregion
    }
}
