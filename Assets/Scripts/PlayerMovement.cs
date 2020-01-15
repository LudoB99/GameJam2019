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

public enum PlayerDirection
{
    up, right, left, down
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public PlayerDirection currentFacingDirection;
    public PlayerDirection currentMovingDirection;
    public float speed;
    public GameObject lantern;
    public AudioSource footstepSound;
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
        UpdateFaceDirection();
        UpdateMovement();
    }

    void UpdateMovement()
    {
        UpdatePosition();
        UpdateMovingPosition();
        Move();
    }

    private void UpdateMovingPosition()
    {
        if (position.x == 0 && position.y == 1)
        {
            currentMovingDirection = PlayerDirection.up;
        } else if (position.x == 1 && position.y == 0)
        {
            currentMovingDirection = PlayerDirection.right;
        }else if (position.x == -1 && position.y == 0)
        {
            currentMovingDirection = PlayerDirection.left;
        }else if (position.x == 0 && position.y == -1)
        {
            currentMovingDirection = PlayerDirection.down;
        }
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
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
            position.Normalize();
            if (currentFacingDirection == currentMovingDirection)
            {
                body2D.MovePosition(transform.position + position * speed * Time.deltaTime );
                animator.speed = 1f;
            }
            else
            {
                body2D.MovePosition(transform.position + position * (speed/2) * Time.deltaTime );
                animator.speed = 0.5f;
            }
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

    private void UpdateFaceDirection()
    {
        Vector3 faceDirection = GetMouseAngle();
        if (faceDirection.z <= 135 && faceDirection.z >= 45)
        {
            animator.SetFloat("MoveY", 1);
            animator.SetFloat("MoveX", 0);
            currentFacingDirection = PlayerDirection.up;
            lantern.transform.rotation = Quaternion.Euler(0, 0, 90);
            
        } else if (faceDirection.z < 45 && faceDirection.z > -45)
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", 1);
            currentFacingDirection = PlayerDirection.right;
            lantern.transform.rotation = Quaternion.Euler(0, 0, 0);
            
        } else if (faceDirection.z < -45 && faceDirection.z > -135)
        {
            animator.SetFloat("MoveY", -1);
            animator.SetFloat("MoveX", 0);
            currentFacingDirection = PlayerDirection.down;
            lantern.transform.rotation = Quaternion.Euler(0, 0, 270);
            
        } else if (faceDirection.z > 135 || faceDirection.z < -135)
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", -1);
            currentFacingDirection = PlayerDirection.left;
            lantern.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    private Vector3 GetMouseAngle()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        return new Vector3(0, 0, angle);
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vector.z = 0f;
        return vector;
    }
}
