using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public LayerMask layerMask;
    public bool isObstacle = false;
    public float radiusSphere;
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusSphere, layerMask);

        if (hitColliders.Length > 0)
        {
            foreach (Collider item in hitColliders) 
            {
                if (item.gameObject.CompareTag("Obstacle"))
                {
                    isObstacle = true;
                    Debug.Log(item.gameObject);
                    Debug.Log("is Obstacle true");
                }
                if (item.gameObject.CompareTag("EnemyTag") && isObstacle == false)
                {
                    Debug.Log(item.tag);
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
