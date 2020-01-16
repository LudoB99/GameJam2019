using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBarrelScript : Interactable
{
    public Player player;

    // Update is called once per frame
    public override void Interact()
    {
        if (Input.GetButtonDown("Collect") && playerInRange && player.hasAxe)
        {
            Destroy(this.gameObject);
            //RefillSound.Play();
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
