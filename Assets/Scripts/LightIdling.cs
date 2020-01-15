using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIdling : MonoBehaviour
{
    public Light LightSource;
    float timer; 
    private float Intensity;
    // Start is called before the first frame update

    void Start()
    {
        Intensity = LightSource.intensity;
        timer = 0;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Intensity = oscillate(timer, 6, 8);
        LightSource.intensity = Math.Abs(Intensity); 
    }

    float oscillate(float time, float speed, float scale)
    {
        return (Mathf.Cos(time * speed / Mathf.PI) * scale) + 30;
    }

}
