using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgrade : MonoBehaviour
{
    const int MENU_SIZE = GameUpgrade.MENU_SIZE;

    public static GameObject[] upgrades = new GameObject[MENU_SIZE];

    public static bool[] attackUnlocked = new bool[MENU_SIZE];
    public static bool[] defenseUnlocked = new bool[MENU_SIZE];
    public static bool[] utilityUnlocked = new bool[MENU_SIZE];
    public static bool[] topSecretUnlocked = new bool[MENU_SIZE];

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
        if (menu == GameUpgrade.Menu.Attack.ToString())
        {
            SetUpgrade(attackUnlocked, GameUpgrade.attackTitles);
        }
        else if (menu == GameUpgrade.Menu.Defense.ToString())
        {
            SetUpgrade(defenseUnlocked, GameUpgrade.defenseTitles);
        }
        else if (menu == GameUpgrade.Menu.Utility.ToString())
        {
            SetUpgrade(utilityUnlocked, GameUpgrade.utilityTitles);
        }
        else if (menu == GameUpgrade.Menu.TopSecret.ToString())
        {
            SetUpgrade(topSecretUnlocked, GameUpgrade.topSecretTitles);
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

    public void UnlockUpgrade(bool[] unlocked, int i)
    {
        if (!unlocked[i])
        {
            unlocked[i] = true;
        }
    }
}
