using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIdling : MonoBehaviour
{
    public Light LightSource;
    private float Intensity;
    // Variables pour builder la fonction cos
    public float b; // Éviter que la fonction tombe dans le négatif; 
    public float timer;
    public float speed;
    public float scale; 
    // Start is called before the first frame update

    void Start()
    {
        Intensity = LightSource.intensity;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        Intensity = oscillate(timer, speed, scale);
        LightSource.intensity = Math.Abs(Intensity); 
    }

    float oscillate(float time, float speed, float scale)
    {
        return (Mathf.Cos(time * speed / Mathf.PI) * scale) + b; 
    }
}
