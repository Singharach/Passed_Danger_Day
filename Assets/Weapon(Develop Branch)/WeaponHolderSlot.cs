using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WeaponHolderSlot : MonoBehaviour
    {
        public Transform parentOverride;
        public bool isLeftHandSlot;
        public bool isRightHandSlot;

        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if (currentWeaponModel != null) 
            {
                currentWeaponModel.SetActive(false); //SetActive used to deactivate a game object
            }
        }

        public void UnloadWeaponAndDestroy()
        {
            if (currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }

        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            UnloadWeaponAndDestroy(); //function that unloads a weapon and destroys it

            if (weaponItem == null)
            {
                UnloadWeapon(); //function that unloads the current weapon
                return;
            }

            GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject; //
            if (model != null)
            {
                if (parentOverride != null)
                {
                    model.transform.parent = parentOverride; //sets the parent model.transform to parentOverride
                }
                else
                {
                    model.transform.parent = transform; //sets the parent model transform to the transform variable
                }

                model.transform.localPosition = Vector3.zero; //sets
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
            }

            currentWeaponModel = model; //assigns the value of the variable "model" to the variable "currentWeaponModel"
        }
    }
}
