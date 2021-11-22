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

    public float[] bounty = new float[2];
    public bool targeted;

    public float attack;
    public float health;
    public float speedMax;
    public float speedCurrent;

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
        if (GameLevel.inProgress)
        {
            if (distanceToTower > (diameter / 2) + 0.5)
            {
                speedCurrent = distanceToTower > Tower.range / 2 ? speedMax : speedMax * ((100 - Tower.slowAura) / 100);

                Vector3 dir = new Vector3(xEnd, 0, zEnd) - new Vector3(xStart, 0, zStart);
                float dist = Mathf.Sqrt(
                    Mathf.Pow(xEnd - xStart, 2) +
                    Mathf.Pow(zEnd - zStart, 2));
                transform.Translate(dir.normalized * dist * (Time.deltaTime) * speedCurrent);
                distanceToTower = Mathf.Sqrt(Mathf.Pow(GetComponent<Transform>().position.x, 2) + Mathf.Pow(GetComponent<Transform>().position.z, 2));
            
                if (distanceToTower <= (diameter / 2) + 0.5)
                {
                    Damage damage = new Damage();
                    damage.DealDamageToTower(attack);
                    damage.KillEnemy(transform);
                    Destroy(gameObject);
                }
            }
        }
    }
}
