using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public static GameObject tower;
    public static GameObject rangeIndicator;

    public static float attackDamage;
    public static float attackSpeed;
    public static float range;
    public static float projectileSpeed;
    public static float criticalChance;
    public static float criticalDamage;
    public static float multishot;
    public static float damagePerKill;

    public static float healthMax;
    public static float healthCurrent;
    public static float regeneration;
    public static float percentageBlock;
    public static float flatBlock;
    public static float divineShield;
    public static bool shielded;
    public static float slowAura;
    public static float lifeSteal;
    public static float healthPerKill;

    public static float goldPerLevel;
    public static float crystalsPerLevel;
    public static float goldValue;
    public static float crystalValue;
    public static float attackUpgrade;
    public static float defenseUpgrade;
    public static float utilityUpgrade;
    public static float goldInterest;



    public void Init()
    {
        rangeIndicator = GameObject.Find("RangeIndicator");
        CreateTower();
    }

    public void SetStats()
    {
        SetAttackDamage();
        SetAttackSpeed();
        SetRange();
        SetProjectileSpeed();
        SetCriticalChance();
        SetCriticalDamage();
        SetMultishot();
        SetDamagePerKill();

        SetHealth();
        SetRegeneration();
        SetPercentageBlock();
        SetFlatBlock();
        SetDivineShield();
        SetSlowAura();
        SetLifeSteal();
        SetHealthPerKill();

        SetGoldPerLevel();
        SetCrystalsPerLevel();
        SetGoldValue();
        SetCrystalValue();
        SetAttackUpgrade();
        SetDefenseUpgrade();
        SetUtilityUpgrade();
        SetGoldInterest();

    }

    public void CreateTower()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Tower");
        GameObject parent = GameObject.Find("Towers");
        tower = Instantiate(prefab, new Vector3(0, 0), new Quaternion(0, 0, 0, 0), parent.transform);
    }

    public bool Attack()
    {
        Enemy enemy = new Enemy();
        bool returnValue = false;
        for (int i = 0; i < multishot; i++)
        {
            Transform target = enemy.GetNearestUntargetedEnemy();
            if (target)
            {
                target.gameObject.GetComponent<EnemyInstance>().targeted = true;
                GameObject prefab = Resources.Load<GameObject>("Assets/Projectile");
                GameObject parent = GameObject.Find("Projectiles");
                prefab.GetComponent<ProjectileInstance>().target = target;
                Instantiate(prefab, new Vector3(0, tower.transform.localScale.y * 2, 0), new Quaternion(0, 0, 0, 0), parent.transform);
                returnValue = true;
            }
        }
        enemy.UntargetAllEnemies();
        return returnValue;
    }

    public void SetIndicators()
    {
        tower.transform.localScale = new Vector3(1, range / 10, 1);
        tower.transform.position = new Vector3(0, tower.transform.localScale.y, 0);
        rangeIndicator.transform.localScale = new Vector3(range * 2, 0.1f, range * 2);
        Cam cam = new Cam();
        cam.SetCamFromRange(range);
    }

    public void Heal(float amount)
    {
        healthCurrent += amount;
        if (healthCurrent > healthMax)
        {
            healthCurrent = healthMax;
        }
        UI ui = new UI();
        ui.DisplayHealthBar();
    }

    public void SetAttackDamage()
    {
        attackDamage = 10 * Mathf.Pow(1.1f, Upgrade.attackCurrentLevels[0]);
    }
    public void SetAttackSpeed()
    {
        attackSpeed = 1 + (0.05f * Upgrade.attackCurrentLevels[1]);
    }

    public void SetRange()
    {
        range = 5 + (0.5f * Upgrade.attackCurrentLevels[2]);
        SetIndicators();
    }

    public void SetProjectileSpeed()
    {
        projectileSpeed = 1 + (0.1f * Upgrade.attackCurrentLevels[3]);
    }

    public void SetCriticalChance()
    {
        criticalChance = 0 + (2 * Upgrade.attackCurrentLevels[4]);
    }

    public void SetCriticalDamage()
    {
        criticalDamage = 200 + (6 * Upgrade.attackCurrentLevels[5]);
    }

    public void SetMultishot()
    {
        multishot = 1 + (1 * Upgrade.attackCurrentLevels[6]);
    }

    public void SetDamagePerKill()
    {
        damagePerKill = 0 + (1 * Upgrade.attackCurrentLevels[7]);

    }
    public void SetHealth()
    {
        healthMax = 10 * Mathf.Pow(1.1f, Upgrade.defenseCurrentLevels[0]);
        UI ui = new UI();
        ui.DisplayHealthBar();
    }


    public void SetRegeneration()
    {
        regeneration = 0.1f * Mathf.Pow(1.1f, Upgrade.defenseCurrentLevels[1]);
    }

    public void SetPercentageBlock()
    {
        percentageBlock = 0 + (1 * Upgrade.defenseCurrentLevels[2]);
    }

    public void SetFlatBlock()
    {
        flatBlock = 0 + (Mathf.Pow(Upgrade.defenseCurrentLevels[3]/2, 2) + (Upgrade.defenseCurrentLevels[3] / 2));
    }

    public void SetDivineShield()
    {
        divineShield = 0 + (0.25f * Upgrade.defenseCurrentLevels[4]);
        shielded = false;
    }

    public void SetSlowAura()
    {
        slowAura = 0 + (2 * Upgrade.defenseCurrentLevels[5]);
    }

    public void SetLifeSteal()
    {
        lifeSteal = 0 + (5 * Upgrade.defenseCurrentLevels[6]);
    }

    public void SetHealthPerKill()
    {
        healthPerKill = 0 + (1 * Upgrade.defenseCurrentLevels[7]);
    }

    public void SetGoldPerLevel()
    {
        goldPerLevel = 0 + ((10 + (Upgrade.utilityCurrentLevels[0] * 2)) * Upgrade.utilityCurrentLevels[0]);
    }

    public void SetCrystalsPerLevel()
    {
        crystalsPerLevel = 0 + ((1 + (Upgrade.utilityCurrentLevels[1] * 0.2f)) * Upgrade.utilityCurrentLevels[1]);
    }

    public void SetGoldValue()
    {
        goldValue = 100 + (5 * Upgrade.utilityCurrentLevels[2]);
    }

    public void SetCrystalValue()
    {
        crystalValue = 100 + (5 * Upgrade.utilityCurrentLevels[3]);
    }

    public void SetAttackUpgrade()
    {
        attackUpgrade = 0 + (2 * Upgrade.utilityCurrentLevels[4]);
    }

    public void SetDefenseUpgrade()
    {
        defenseUpgrade = 0 + (2 * Upgrade.utilityCurrentLevels[5]);
    }

    public void SetUtilityUpgrade()
    {
        utilityUpgrade = 0 + (2 * Upgrade.utilityCurrentLevels[6]);
    }

    public void SetGoldInterest()
    {
        goldInterest = 0 + (10 * Upgrade.utilityCurrentLevels[7]);
    }
}
