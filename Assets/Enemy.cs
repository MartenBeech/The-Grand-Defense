using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum Types {Normal, Strong, Boss}

    Rng rng = new Rng();
    private static long spawnId = 0;

    public void Init()
    {
        CreateEnemies(10, Types.Normal);
    }
    public void CreateEnemies(int amount, Types type)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("Assets/Enemy");
            GameObject parent = GameObject.Find("Enemies");
            int[] pos = rng.Distance(10, 20);
            int xPos = pos[0];
            int zPos = pos[1];
            SetStats(prefab, type);
            Instantiate(prefab, new Vector3(xPos, 0, zPos), new Quaternion(0, 0, 0, 0), parent.transform);
            spawnId++;
        }
    }

    public void SetStats(GameObject prefab, Types type)
    {
        prefab.GetComponent<EnemyInstance>().targeted = false;

        switch (type)
        {
            case Types.Normal:
                prefab.name = $"Normal{spawnId}";
                prefab.GetComponent<EnemyInstance>().diameter = 1;
                prefab.GetComponent<EnemyInstance>().health = 10;
                prefab.GetComponent<EnemyInstance>().attack = 1;
                break;
        }
    }

    public Transform GetNearestUntargetedEnemy()
    {
        Transform parent = GameObject.Find("Enemies").transform;
        int parentCount = parent.childCount;
        float lowestDistance = 0;
        Transform target = null;
        for (int i = 0; i < parentCount; ++i)
        {
            Transform child = parent.GetChild(i);
            float distance = child.gameObject.GetComponent<EnemyInstance>().distanceToTower;
            bool targeted = child.gameObject.GetComponent<EnemyInstance>().targeted;
            if (!targeted && distance <= Tower.range)
            {
                if (distance < lowestDistance || lowestDistance == 0)
                {
                    lowestDistance = distance;
                    target = child;
                }
                
            }
        }
        return target;
    }
}
