using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float OilQuantity;

    private Animator animator;
    public PlayerDirection currentDirection;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void RefillOil()
    {
        OilQuantity = 100;
    }
}
