using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInstance : MonoBehaviour
{
    public float attackCounter;
    public float regenerationInterval;
    public float regenerationCounter;
    public float divineShieldCounter;

    private void Awake()
    {
        attackCounter = 1f / Tower.attackSpeed;
        regenerationInterval = 1f / 100;
        regenerationCounter = regenerationInterval;
        divineShieldCounter = 10 - (Tower.divineShield / 2);
    }

    private void Update()
    {
        if (GameLevel.inProgress)
        {
            if (attackCounter > 0)
            {
                attackCounter -= Time.deltaTime;
            }
            if (attackCounter <= 0)
            {
                Tower tower = new Tower();
                if (tower.Attack())
                {
                    attackCounter += 1f / Tower.attackSpeed;
                }
            }

            if (Tower.healthCurrent < Tower.healthMax)
            {
                if (regenerationCounter > 0)
                {
                    regenerationCounter -= Time.deltaTime;
                }
                if (regenerationCounter <= 0)
                {
                    Tower tower = new Tower();
                    tower.Heal(Tower.regeneration * regenerationInterval);
                    regenerationCounter += regenerationInterval;
                }
            }

            if (Tower.divineShield > 0 && !Tower.shielded)
            {
                if (divineShieldCounter > 0)
                {
                    divineShieldCounter -= Time.deltaTime;
                }
                if (divineShieldCounter <= 0)
                {
                    Tower.shielded = true;
                    UI ui = new UI();
                    ui.SetHealthBarColor();
                    divineShieldCounter = 10 - (Tower.divineShield / 2);
                }
            }
        }
    }
}
