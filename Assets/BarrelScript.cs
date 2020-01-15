using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public SignalScript context;
    public Player Player;
    public AudioSource RefillSound;
    private bool playerTouchingBarrel;

    void Update()
    {
        if (Input.GetButtonDown("Collect") && playerTouchingBarrel)
        {
            Player.RefillOil();
            RefillSound.Play();
            Debug.Log("Salut");
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && !hitInfo.isTrigger)
        {
            context.Raise();
            playerTouchingBarrel = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && !hitInfo.isTrigger)
        {
            context.Raise();
            playerTouchingBarrel = false;
        }
    }
}
