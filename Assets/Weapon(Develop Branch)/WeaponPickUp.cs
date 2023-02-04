using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class WeaponPickUp : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager) //override of the Interact() method in a parent class
        {
            base.Interact(playerManager); //calls Interact() method on the base object

            PickUpItem(playerManager); //PickUpItem
        }

        private void PickUpItem(PlayerManager playerManager) //takes a PlayerManager object as an argument
        {
            PlayerInventory playerInventory; //creates a PlayerInventory object called playerInventory
            PlayerLocomotion playerLocomotion; //creates an instance of the PlayerLocomotion class called playerLocomotion
            AnimatorHandler animatorHandler;

            playerInventory = playerManager.GetComponent<PlayerInventory>(); //retrieving the PlayerInventory component from the playerManager object
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>(); //used to get the PlayerLocomotion component from the playerManager object
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>(); //retrieving the AnimatorHandler component from the playerManager game object's children

            playerLocomotion.rigidbody.velocity = Vector3.zero; //Stops the player from moving whilst picking up item
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //Plays the animation of looting the item
            playerInventory.weaponInventory.Add(weapon); //adds a weapon to the player's weapon inventory
            playerManager.itemInteractableGameObject.GetComponentInChildren<Text>().text = weapon.itemName; //sets text of Text component that is a child of the itemInteractableGameObject in the playerManager to the itemName property of the weapon object
            playerManager.itemInteractableGameObject.GetComponentInChildren<RawImage>().texture = weapon.itemIcon.texture; //assign the texture of a weapon's item icon to the RawImage
            playerManager.itemInteractableGameObject.SetActive(true); //activates itemInteractableGameObject of the playerManager
            Destroy(gameObject); //destroy the game object it is called on
        }
    }
}
