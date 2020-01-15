using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{ 
    public Player Player;
    private bool playerTouchingBarrel;

    void Update()
    {
        if (Input.GetButtonDown("Collect") && playerTouchingBarrel)
        {
            Player.RefillOil();
            Debug.Log("Salut");
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            playerTouchingBarrel = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            playerTouchingBarrel = false;
        }
    }
}
