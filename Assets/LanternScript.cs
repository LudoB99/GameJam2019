using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    public float OilQuantity;
    public Light Light;
    public Collider2D Huge;
    public Collider2D Mid;
    public Collider2D Little;
    
    void Start()
    {
        InvokeRepeating("ConsumeOil", 2.0f, 1.0f);
    }

    void Update()
    {
        Light.range = OilQuantity;

        if (OilQuantity < 0)
        {
            Little.enabled = false;
        }
        else
        {
            if (OilQuantity < 5)
            {
                Mid.enabled = false;
            }
            else
            {
                if (OilQuantity < 10)
                {
                    Huge.enabled = false;
                }
            }
        }
    }

    private void ConsumeOil()
    {
        OilQuantity -= 0.66f;
    }
    
    public void RefillOil()
    {
        OilQuantity = 10;
        Huge.enabled = true;
        Mid.enabled = true;
        Little.enabled = true;
    }
}
