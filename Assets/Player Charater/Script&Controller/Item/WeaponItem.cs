using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "Item/Weapon Item")] //create a menu
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idel Animations")] //header is labeling a section of code that contains idle animations.
        public string right_hand_idle; //variable is a string used to store the name of an idle animation for a right hand
        public string left_hand_idle;


        [Header("One Handed Attack Animation")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;
        
        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
    }
}