using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public SignalScript context;
    public GameObject DialogBox;
    public Text DialogText;
    public string Dialog;

    public abstract void Interact();

    void Update()
    {
        Interact();
    }

    void EnableDialogComponent()
    {

    }

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

        DialogBox.SetActive(false);
    }
}
