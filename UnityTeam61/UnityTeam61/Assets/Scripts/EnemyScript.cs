using System;
using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(10, 0, 0);
    public float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = position2;
    }

    void Update()
    {
        // Move the GameObject towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the GameObject has reached the target position
        if (transform.position == targetPosition)
        {
            // Switch target position
            targetPosition = targetPosition == position1 ? position2 : position1;
        }
    }
}
