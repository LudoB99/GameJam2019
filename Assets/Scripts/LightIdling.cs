using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIdling : MonoBehaviour
{
    public Light LightSource;
    private float Intensity;
    // Variables pour builder la fonction cos
    private float timer;
    private float speed;
    private float scale; 
    // Start is called before the first frame update

    void Start()
    {
        Intensity = LightSource.intensity;
        speed = 8; 
        timer = 0;
        scale = 10; 
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Intensity = oscillate(timer, speed, scale);
        LightSource.intensity = Math.Abs(Intensity); 
    }

    float oscillate(float time, float speed, float scale)
    { 
        int b = 30; // Éviter que la fonction tombe dans le négatif; 
        return (Mathf.Cos(time * speed / Mathf.PI) * scale) + b; 
    }
}
