using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed=1f; // speed
    public float length= 10f; // length from 0 to endpoint.
    public float posX = 1f; 
    public float posZ = 3f;

    public int enemyHp;

    public GameObject colliderChecker;

    private void Start()
    {
    }

    void Update() 
    {
        Vector3 pos = new Vector3 ( posX+Mathf.PingPong (speed * Time.time, length),0.75f, posZ+Mathf.PingPong(speed * Time.time, length));
        transform.position = pos;
    }
}
