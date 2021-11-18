using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInstance : MonoBehaviour
{
    public float attackInterval;

    private void Awake()
    {
        attackInterval = 1f / Tower.attackSpeed;
    }

    private void Update()
    {
        if (Game.inProgress)
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
                    attackInterval = 1f / Tower.attackSpeed;
                }
            }
        }
    }
}
