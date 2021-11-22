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
        SetStats();
        CreateTower();
    }

    public void SetStats()
    {
        attackDamage = 10;
        attackSpeed = 1;
        range = 5;
        projectileSpeed = 1;
        criticalChance = 0;
        criticalDamage = 200;
        multishot = 1;
        damagePerKill = 0;

        healthMax = 10;
        healthCurrent = healthMax;
        regeneration = 0.1f;
        percentageBlock = 0;
        flatBlock = 0;
        divineShield = 0;
        shielded = false;
        slowAura = 0;
        lifeSteal = 0;
        healthPerKill = 0;

        goldPerLevel = 0;
        crystalsPerLevel = 0;
        goldValue = 100;
        crystalValue = 100;
        attackUpgrade = 0;
        defenseUpgrade = 0;
        utilityUpgrade = 0;
        goldInterest = 0;

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
            else
            {
                return false;
            }
        }
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
}
