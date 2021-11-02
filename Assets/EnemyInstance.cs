using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInstance : MonoBehaviour
{
    private float xStart;
    private float zStart;
    private float xEnd;
    private float zEnd;

    public float distanceToTower;

    public int attack;
    public int health;
    public bool targeted;

    private void Awake()
    {
        xStart = GetComponent<Transform>().position.x;
        zStart = GetComponent<Transform>().position.z;
        xEnd = 0;
        zEnd = 0;
        distanceToTower = Mathf.Sqrt(Mathf.Pow(xStart, 2) + Mathf.Pow(zStart, 2));
    }

    void Update()
    {
        if (distanceToTower > 1)
        {
            Vector3 dir = new Vector3(xEnd, 0, zEnd) - new Vector3(xStart, 0, zStart);
            float dist = Mathf.Sqrt(
                Mathf.Pow(xEnd - xStart, 2) +
                Mathf.Pow(zEnd - zStart, 2));
            transform.Translate(dir.normalized * dist * (Time.deltaTime) * 0.01f);
            distanceToTower = Mathf.Sqrt(Mathf.Pow(GetComponent<Transform>().position.x, 2) + Mathf.Pow(GetComponent<Transform>().position.z, 2));
        }
    }
}
