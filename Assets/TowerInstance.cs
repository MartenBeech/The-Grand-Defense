using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInstance : MonoBehaviour
{
    public float attackIntervalMax;
    public float attackInterval;

    private void Awake()
    {
        attackIntervalMax = 1f / Tower.attackSpeed;
        attackInterval = attackIntervalMax;
    }

    private void Update()
    {
        if (attackInterval > 0)
        {
            attackInterval -= Time.deltaTime;
        }
        if (attackInterval <= 0)
        {
            Tower tower = new Tower();
            if (tower.Attack())
            {
                attackInterval = attackIntervalMax;
            }
        }
    }
}
