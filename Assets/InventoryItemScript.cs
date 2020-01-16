using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : Interactable
{
    public GameObject InventoryIcon;
    public Player Player;

    public override void Interact()
    {
        if (Input.GetButtonDown("Collect") && playerInRange)
        {
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
                DialogText.text = Dialog;
            }


            this.gameObject.SetActive(false);
            InventoryIcon.SetActive(true);

            if (this.CompareTag("Axe"))
            {
                Player.hasAxe = true;
            }
            else if (this.CompareTag("Shovel"))
            {
                Player.hasShovel = true;
            }
            if (this.CompareTag("Rope"))
            {
                Player.hasRope = true;
            }

           
        }
    }
}
