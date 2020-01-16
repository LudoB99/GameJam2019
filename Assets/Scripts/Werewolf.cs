using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Werewolf : Enemy
{
    public Transform light;
    public int cooldownAttack;

    private bool stop;
    public AudioSource heartbeatSound;
    private Transform target;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
        HeartBeat();
    }

    private void Walk()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        ChangeAnimator(temp - transform.position);
        rigidBody.MovePosition(temp);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void SetAnimatorFloat(Vector2 vector)
    {
        animator.SetFloat("MoveX", vector.x);
        animator.SetFloat("MoveY", vector.y);
    }

    private void ChangeAnimator(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lantern"))
        {
            moveSpeed = -3;
            Invoke("RunAway", 1.0f);
        }
    }

    private void RunAway()
    {
        transform.position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F), 0);
        moveSpeed = 1;
    }

    private void HeartBeat()
    {
        distance = Vector3.Distance(transform.position, target.position);
       // Debug.Log(distance);

        if (distance < 10)
        {
            if (!heartbeatSound.isPlaying)
            {
                heartbeatSound.Play();
            }
        }
        else
        {
            heartbeatSound.Pause();

        }
        
        if (distance < 5 && heartbeatSound.isPlaying)
        {
            heartbeatSound.volume = 1;
        }
        else
        {
            if (distance < 8 && heartbeatSound.isPlaying)
            {
                heartbeatSound.volume = 0.5f;
            }
            else
            {
                heartbeatSound.volume = 0.1f;
            }
        }
    }
}
