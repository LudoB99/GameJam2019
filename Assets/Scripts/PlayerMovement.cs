using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D body2D;
    private Vector3 position;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.Walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        UpdatePosition();
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.Attack) Attack();
        else if (currentState == PlayerState.Walk) Move();
    }

    private void Attack()
    {
        StartCoroutine(Routine(.3f,
            () =>
            {
                animator.SetBool("Attacking", true);
                currentState = PlayerState.Attack;
            },
            () =>
            {
                animator.SetBool("Attacking", false);
            },
            () =>
            {
                currentState = PlayerState.Walk;
            }
        ));
    }

    private IEnumerator Routine(float waitTime, Action action, Action reset, Action after)
    {
        action();
        yield return null;
        reset();
        yield return new WaitForSeconds(waitTime);
        after();
    }

    private void Move()
    { 
        if (IsMoving())
        {
            position.Normalize();
            body2D.MovePosition( transform.position + position * speed * Time.deltaTime );
            animator.SetFloat("MoveX", position.x);
            animator.SetFloat("MoveY", position.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void UpdatePosition()
    {
        position = Vector3.zero;
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
    }

    private bool IsMoving()
    {
        return position != Vector3.zero;
    }

    
}
