using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgrade : MonoBehaviour
{
    const int MENU_SIZE = Upgrade.MENU_SIZE;

    public static GameObject[] upgrades = new GameObject[MENU_SIZE];

    public static bool[] attackUnlocked = new bool[MENU_SIZE];
    public static bool[] defenseUnlocked = new bool[MENU_SIZE];
    public static bool[] utilityUnlocked = new bool[MENU_SIZE];
    public static bool[] topSecretUnlocked = new bool[MENU_SIZE];
    // Speed up button - Automatic upgrade attack - Automatic upgrade defense - Automatic upgrade utility - Start next wave button - Free camera - Freeze Enemies - NUKE

    public void Init()
    {
        for (int i = 0; i < MENU_SIZE; i++)
        {
            upgrades[i] = GameObject.Find($"MenuUpgrade{i}");
        }

        OpenMenu("Attack");
    }

    public void OpenMenu(string menu)
    {
        if (menu == Upgrade.Menu.Attack.ToString())
        {
            SetUpgrade(attackUnlocked, Upgrade.attackTitles);
            Upgrade.currentMenu = Upgrade.Menu.Attack; 
        }
        else if (menu == Upgrade.Menu.Defense.ToString())
        {
            SetUpgrade(defenseUnlocked, Upgrade.defenseTitles);
            Upgrade.currentMenu = Upgrade.Menu.Defense;
        }
        else if (menu == Upgrade.Menu.Utility.ToString())
        {
            SetUpgrade(utilityUnlocked, Upgrade.utilityTitles);
            Upgrade.currentMenu = Upgrade.Menu.Utility;
        }
        else if (menu == Upgrade.Menu.TopSecret.ToString())
        {
            SetUpgrade(topSecretUnlocked, Upgrade.topSecretTitles);
            Upgrade.currentMenu = Upgrade.Menu.TopSecret;
        }
    }

    public void SetUpgrade(bool[] unlocked, string[] title)
    {
        for (int i = 0; i < MENU_SIZE; i++)
        {
            if (unlocked[i])
            {
                upgrades[i].GetComponent<Image>().enabled = true;
                upgrades[i].GetComponent<Button>().enabled = true;
                upgrades[i].GetComponentInChildren<Text>().text = title[i];
            }
            else if (!unlocked[i])
            {
                upgrades[i].GetComponent<Image>().enabled = false;
                upgrades[i].GetComponent<Button>().enabled = false;
                upgrades[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }
}
