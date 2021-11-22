using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileInstance : MonoBehaviour
{
    private float xStart;
    private float yStart;
    private float zStart;
    public Transform target;
    private float count;

    private void Awake()
    {
        xStart = transform.position.x;
        yStart = transform.position.y;
        zStart = transform.position.z;
        count = 1f / Tower.projectileSpeed;
    }

    void Update()
    {
        if (GameLevel.inProgress)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Vector3 dir = new Vector3(target.position.x, target.position.y, target.position.z) - new Vector3(xStart, yStart, zStart);
                float dist = Mathf.Sqrt(
                    Mathf.Pow(target.position.x - xStart, 2) +
                    Mathf.Pow(target.position.y - yStart, 2) +
                    Mathf.Pow(target.position.z - zStart, 2));
                transform.Translate(dir.normalized * dist * (Time.deltaTime) * Tower.projectileSpeed);
                count -= Time.deltaTime;

                if (Mathf.Abs(GetComponent<Transform>().position.x + GetComponent<Transform>().position.z) > Mathf.Abs(target.position.x + target.position.z) || count <= 0)
                {
                    Damage damage = new Damage();
                    damage.DealDamageToEnemy(target);
                    Destroy(gameObject);
                }
            }
        }
    }
}
