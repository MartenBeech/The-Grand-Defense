using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public void DealDamageToEnemy(Transform target)
    {
        target.gameObject.GetComponent<EnemyInstance>().health -= Tower.attack;
        target.gameObject.GetComponent<EnemyInstance>().targeted = false;
        if (target.gameObject.GetComponent<EnemyInstance>().health <= 0)
        {
            Destroy(target.gameObject);
        }
    }

    public void DealDamageToTower(int i)
    {
        Tower.health -= i;
        if (Tower.health <= 0)
        {
            DestroyTower();
        }
    }

    public void DestroyTower()
    {

    }
}
