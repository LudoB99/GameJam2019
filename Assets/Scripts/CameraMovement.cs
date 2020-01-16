using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sleepTime;
    public Transform target;
    public float deadlinesOnTarget;
    public Vector2 maxPositionMap; //(6.25, 14)
    public Vector2 minPositionMap; //(-20.35, -2)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!IsSamePosition()) StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(sleepTime);
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        targetPosition = Bounding(targetPosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, deadlinesOnTarget);
    }

    private IEnumerator SleepMethod()
    {
        yield return new WaitForSeconds(sleepTime);
    }

    private Vector3 Bounding(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, minPositionMap.x, maxPositionMap.x);
        position.y = Mathf.Clamp(position.y, minPositionMap.y, maxPositionMap.y);
        return position;
    }

    private bool IsSamePosition()
    {
        return transform.position == target.position;
    }
}
