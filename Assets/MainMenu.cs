using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image black;
    public Animator anim;
    public AudioSource breakingInHouse;
    public AudioSource ambianceSound;
    public AudioSource ambianceFire;
    
    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        ambianceSound.Pause();
        ambianceFire.Pause();
        yield return new WaitForSeconds(1);
        breakingInHouse.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
