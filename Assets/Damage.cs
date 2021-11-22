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
        float damage;
        bool criticalHit = rng.Chance(Tower.criticalChance);
        if (criticalHit)
        {
            damage = Tower.attackDamage * Tower.criticalDamage / 100f;
        }
        else
        {
            damage = Tower.attackDamage;
        }
        Tower tower = new Tower();
        tower.Heal(damage * Tower.lifeSteal / 100);
        target.gameObject.GetComponent<EnemyInstance>().health -= damage;
        target.gameObject.GetComponent<EnemyInstance>().targeted = false;
        if (target.gameObject.GetComponent<EnemyInstance>().health <= 0)
        {
            KillEnemy(target);
        }
    }

    public void DealDamageToTower(float damage)
    {
        if (Tower.shielded)
        {
            Tower.shielded = false;
            UI ui = new UI();
            ui.SetHealthBarColor();
        }
        else
        {
            damage *= ((100 - Tower.percentageBlock) / 100);
            damage -= Tower.flatBlock;
            if (damage > 0)
            {
                Tower.healthCurrent -= damage;
                UI ui = new UI();
                ui.DisplayHealthBar();
                if (Tower.healthCurrent <= 0)
                {
                    KillTower();
                }
            }
        }
    }

    public void KillEnemy(Transform target)
    {
        Money money = new Money();
        money.GainGold(target.gameObject.GetComponent<EnemyInstance>().bounty, true);
        Destroy(target.gameObject);
        if (Tower.damagePerKill > 0)
        {
            Tower.attackDamage *= ((100 + Tower.damagePerKill) / 100f);
            if (Upgrade.currentMenu == Upgrade.Menu.Attack)
            {
                GameUpgrade gameUpgrade = new GameUpgrade();
                gameUpgrade.DisplayUpgradeText(Upgrade.attackTitles, 0);
            }
        }
        if (Tower.healthPerKill > 0)
        {
            float health = ((100 + Tower.healthPerKill) / 100f);
            Tower.healthMax *= health;
            Tower.healthCurrent *= health;
            UI ui = new UI();
            ui.DisplayHealthBar();
            if (Upgrade.currentMenu == Upgrade.Menu.Defense)
            {
                GameUpgrade gameUpgrade = new GameUpgrade();
                gameUpgrade.DisplayUpgradeText(Upgrade.defenseTitles, 0);
            }
        }
    }

    public void KillTower()
    {
        MainMenu menu = new MainMenu();
        menu.EndGame();
    }
}
