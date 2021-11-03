using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    private void Start()
    {
        Enemy enemy = new Enemy();
        enemy.Init();
        Tower tower = new Tower();
        tower.Init();
        Upgrade upgrade = new Upgrade();
        upgrade.Init();
    }
}
