using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public static GameObject tower;
    public static GameObject rangeIndicator;

    public static int attack;
    public static int attackSpeed;
    public static int projectileSpeed;
    public static float range;
    public static int health;

    public void Init()
    {
        rangeIndicator = GameObject.Find("RangeIndicator");
        SetStats();
        CreateTower();
        SetIndicators();
    }

    public void SetStats()
    {
        attack = 1;
        attackSpeed = 1;
        projectileSpeed = 4;
        range = 20;
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
        float camDistance = (range);
        Cam.mainCamera.transform.position = new Vector3(camDistance, camDistance, -camDistance);
    }
}
