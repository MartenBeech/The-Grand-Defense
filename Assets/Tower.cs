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

    public static float health;
    public static float regeneration;
    public static float percentageBlock;
    public static float flatBlock;
    public static float divineShield;
    public static float slowAura;
    public static float lifeSteal;
    public static float healthPerKill;

    public static float goldPerLevel;
    public static float crystalsPerLevel;
    public static float bonusGold;
    public static float bonusCrystals;
    public static float attackUpgrade;
    public static float healthUpgrade;
    public static float utilityUpgrade;
    public static float goldInterest;



    public void Init()
    {
        rangeIndicator = GameObject.Find("RangeIndicator");
        SetStats();
        CreateTower();
        SetIndicators();
    }

    public void SetStats()
    {
        attackDamage = 10;
        attackSpeed = 100;
        range = 5;
        projectileSpeed = 4;
        criticalChance = 0;
        health = 10;
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
        Transform target = enemy.GetNearestUntargetedEnemy();
        if (target)
        {
            target.gameObject.GetComponent<EnemyInstance>().targeted = true;
            GameObject prefab = Resources.Load<GameObject>("Assets/Projectile");
            GameObject parent = GameObject.Find("Projectiles");
            prefab.GetComponent<ProjectileInstance>().target = target;
            Instantiate(prefab, new Vector3(0, tower.transform.localScale.y * 2, 0), new Quaternion(0, 0, 0, 0), parent.transform);
            return true;
        }
        return false;
    }

    public void SetIndicators()
    {
        tower.transform.localScale = new Vector3(1, range / 10, 1);
        tower.transform.position = new Vector3(0, tower.transform.localScale.y, 0);
        rangeIndicator.transform.localScale = new Vector3(range * 2, 0.1f, range * 2);
        Cam cam = new Cam();
        cam.SetCamFromRange(range);
    }
}
