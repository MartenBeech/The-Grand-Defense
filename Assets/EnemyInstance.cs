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

    public float diameter;
    public float distanceToTower;

    public int bounty;
    public bool targeted;

    public int attack;
    public int health;
    public float speed;

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
        if (Game.inProgress)
        {
            if (distanceToTower > (diameter / 2) + 0.5)
            {
                Vector3 dir = new Vector3(xEnd, 0, zEnd) - new Vector3(xStart, 0, zStart);
                float dist = Mathf.Sqrt(
                    Mathf.Pow(xEnd - xStart, 2) +
                    Mathf.Pow(zEnd - zStart, 2));
                transform.Translate(dir.normalized * dist * (Time.deltaTime) * speed);
                distanceToTower = Mathf.Sqrt(Mathf.Pow(GetComponent<Transform>().position.x, 2) + Mathf.Pow(GetComponent<Transform>().position.z, 2));
            
                if (distanceToTower <= (diameter / 2) + 0.5)
                {
                    Damage damage = new Damage();
                    damage.DealDamageToTower(attack);
                    Destroy(gameObject);
                }
            }
        }
    }
}
