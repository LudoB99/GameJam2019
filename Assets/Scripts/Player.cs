using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float OilQuantity;

    private Animator animator;
    public PlayerDirection currentDirection;
    public bool hasAxe;
    public bool hasRope;
    public bool hasShovel;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void RefillOil()
    {
        OilQuantity = 100;
    }

    public void gameEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
