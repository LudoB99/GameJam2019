using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : Interactable
{
    public LanternScript Lantern;
    public AudioSource RefillSound;

    public override void Interact()
    {
        if (Input.GetButtonDown("Collect") && playerInRange)
        {
            Lantern.RefillOil();
            RefillSound.Play();
            if (DialogBox.activeInHierarchy)
            {
                Debug.Log("Active");
                DialogBox.SetActive(false);
            }
            else
            {
                Debug.Log("Not");
                DialogBox.SetActive(true);
                DialogText.text = Dialog;
            }
        }
    }
}
