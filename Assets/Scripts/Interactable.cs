using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public SignalScript context;

    public abstract void Interact();

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && !hitInfo.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && !hitInfo.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
