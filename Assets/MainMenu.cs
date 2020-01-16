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
    private bool transition = false;
    
    private void Update()
    {
        if (Input.GetButtonDown("Submit") && transition == false)
        {
            transition = true;
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        FadeOutTitleScreenSound();
        yield return new WaitForSeconds(2);
        breakingInHouse.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void FadeOutTitleScreenSound()
    {
        StartCoroutine (AudioFade.FadeOut (ambianceSound, 1f));
        StartCoroutine (AudioFade.FadeOut (ambianceFire, 1f));
    }
}
