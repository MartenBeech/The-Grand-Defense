using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public void DealDamageToEnemy(Transform target)
    {
        Rng rng = new Rng();
        bool criticalHit = rng.Chance(Tower.criticalChance);
        if (criticalHit)
        {
            target.gameObject.GetComponent<EnemyInstance>().health -= Tower.attackDamage * Tower.criticalDamage / 100f;
        }
        else
        {
            target.gameObject.GetComponent<EnemyInstance>().health -= Tower.attackDamage;
        }
        target.gameObject.GetComponent<EnemyInstance>().targeted = false;
        if (target.gameObject.GetComponent<EnemyInstance>().health <= 0)
        {
            KillEnemy(target);
        }
    }

    public void DealDamageToTower(float i)
    {
        Tower.health -= i;
        if (Tower.health <= 0)
        {
            KillTower();
        }
    }

    public void KillEnemy(Transform target)
    {
        Money money = new Money();
        money.GainGold(target.gameObject.GetComponent<EnemyInstance>().bounty);
        Destroy(target.gameObject);
    }

    public void KillTower()
    {
        MainMenu menu = new MainMenu();
        menu.EndGame();
    }
}
