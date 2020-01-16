using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGlowingEye : MonoBehaviour
{
    public Animator animator;
    Vector2[] positions = new Vector2[11];
    private bool glowing;
    
    void Start()
    {
        positions[0] = new Vector2(-13.23f, 14.21f);
        positions[1] = new Vector2(-5f, 18f);
        positions[2] = new Vector2(-1f, 17f);
        positions[3] = new Vector2(6f, 18f);
        positions[4] = new Vector2(-11f, 11f);
        positions[5] = new Vector2(8f, 11f);
        positions[6] = new Vector2(6f, 6f);
        positions[7] = new Vector2(8f, 4f);
        positions[8] = new Vector2(-6f, 20f);
        positions[9] = new Vector2(3f, 20f);
        positions[10] = new Vector2(-10f, 18f);
    }

    // Update is called once per frame
    void Update()
    {
        if (glowing == false)
        {
            glowing = true;
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        int positionIndex = Random.Range(0, positions.Length);
        transform.position = positions[positionIndex];
        animator.SetBool("fade", false);
        yield return new WaitForSeconds(4);
        animator.SetBool("fade",true);
        yield return new WaitForSeconds(4);
        glowing = false;
    }
}
