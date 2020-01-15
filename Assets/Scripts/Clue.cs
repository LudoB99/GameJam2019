using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{

    public GameObject clue;
    public bool contextActive = false;

    public void ChangeContext()
    {
        contextActive = !contextActive;

        if (contextActive)
        {
            clue.SetActive(true);
        }
        else
        {
            clue.SetActive(false);
        }
    }

    public void Enable()
    {
        clue.SetActive(true);
    }

    public void Disable()
    {
        clue.SetActive(false);
    }
}
