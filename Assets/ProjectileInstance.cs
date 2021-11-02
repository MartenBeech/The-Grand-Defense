using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileInstance : MonoBehaviour
{
    private float xStart;
    private float zStart;
    public Transform target;
    private float count = 1f / Tower.projectileSpeed;

    private void Awake()
    {
        xStart = 0;
        zStart = 0;
    }

    void Update()
    {
        Vector3 dir = new Vector3(target.position.x, 0, target.position.z) - new Vector3(xStart, 0, zStart);
        float dist = Mathf.Sqrt(
            Mathf.Pow(target.position.x - xStart, 2) +
            Mathf.Pow(target.position.z - zStart, 2));
        transform.Translate(dir.normalized * dist * (Time.deltaTime) * Tower.projectileSpeed);
        count -= Time.deltaTime;

        if (Mathf.Abs(GetComponent<Transform>().position.x + GetComponent<Transform>().position.z) > Mathf.Abs(target.position.x + target.position.z) || count <= 0)
        {
            Tower tower = new Tower();
            tower.DealDamage(target);
            Destroy(gameObject);
        }
    }
}
