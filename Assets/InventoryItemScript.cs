using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemScript : Interactable
{
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
        }
    }
}
