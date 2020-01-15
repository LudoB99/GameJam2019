using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : Interactable
{
    public Player Player;
    public AudioSource RefillSound;

    void Update()
    {
        if (Input.GetButtonDown("Collect") && playerInRange)
        {
            Player.RefillOil();
            RefillSound.Play();
            Debug.Log("Salut");
        }
    }
}
