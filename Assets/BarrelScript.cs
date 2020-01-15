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
            Debug.Log("Salut");
        }
    }

    void Update()
    {
        Interact();
    }
}
