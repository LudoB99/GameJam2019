using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : Interactable
{
    public Player Player;
    public AudioSource RefillSound;

    public override void Interact()
    {
        if (Input.GetButtonDown("Collect") && playerInRange)
        {
            Player.RefillOil();
            RefillSound.Play();
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

        if (DialogBox.activeInHierarchy && !playerInRange)
        {
            DialogBox.SetActive(false);
        }
    }

    void Update()
    {
        Interact();
    }
}
