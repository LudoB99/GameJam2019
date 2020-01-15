using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werewolf : Enemy
{
    public Transform light;
    private Transform target;
    private Rigidbody2D rigidBody;
    private Animator animator;

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

    private void GetPositionByPlayer()
    {
    }
}
