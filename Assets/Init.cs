using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    private void Start()
    {
        Cam cam = new Cam();
        cam.Init();
        Tower tower = new Tower();
        tower.Init();
        Upgrade Upgrade = new Upgrade();
        Upgrade.Init();
        MenuUpgrade menuUpgrade = new MenuUpgrade();
        menuUpgrade.Init();
        MainMenu mainMenu = new MainMenu();
        mainMenu.Init();
        Money money = new Money();
        money.Init();
    }
}
