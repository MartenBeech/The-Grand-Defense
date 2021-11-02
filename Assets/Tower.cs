using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public static GameObject tower;

    private static int attack = 1;
    public static int attackSpeed = 1000;
    public static int projectileSpeed = 4;
    private static int health = 10;

    public void Init()
    {
        CreateTower();
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
            Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), parent.transform);
            return true;
        }
        return false;
    }

    public void DealDamage(Transform target)
    {
        target.gameObject.GetComponent<EnemyInstance>().health -= attack;
        target.gameObject.GetComponent<EnemyInstance>().targeted = false;
        if (target.gameObject.GetComponent<EnemyInstance>().health <= 0)
        {
            Destroy(target.gameObject);
        }
    }
}
