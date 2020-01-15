using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFaceDirection();
    }

    private void UpdateFaceDirection()
    {
        Vector3 faceDirection = GetMouseAngle();
        if (faceDirection.z <= 135 && faceDirection.z >= 45)
        {
            animator.SetFloat("MoveY", 1);
            animator.SetFloat("MoveX", 0);
        } else if (faceDirection.z < 45 && faceDirection.z > -45)
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", 1);
        } else if (faceDirection.z < -45 && faceDirection.z > -135)
        {
            animator.SetFloat("MoveY", -1);
            animator.SetFloat("MoveX", 0);
        } else if (faceDirection.z > 135 || faceDirection.z < -135)
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", -1);
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
