using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public static string[] attackTitles = new string[8] { "Damage", "Attack Speed", "Range", "Projectile Speed", "TBD", "TBD", "TBD", "TBD" };
    public static string[] defenseTitles = new string[8] { "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD" };
    public static string[] utilityTitles = new string[8] { "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD" };
    public static string[] topSecretTitles = new string[8] { "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD" };


    public static GameObject[] upgrades = new GameObject[MENU_SIZE];

    public static bool[] attackUnlocked = new bool[MENU_SIZE];
    public static bool[] defenseUnlocked = new bool[MENU_SIZE];
    public static bool[] utilityUnlocked = new bool[MENU_SIZE];
    public static bool[] topSecretUnlocked = new bool[MENU_SIZE];

    public void Init()
    {
        for (int i = 0; i < MENU_SIZE; i++)
        {
            upgrades[i] = GameObject.Find($"Upgrade{i}");
        }

        UnlockUpgrade(attackUnlocked, 0);
        UnlockUpgrade(attackUnlocked, 1);
        UnlockUpgrade(defenseUnlocked, 0);
        UnlockUpgrade(defenseUnlocked, 1);

        OpenMenu("Attack");
    }

    public void OpenMenu(string menu)
    {
        if (menu == Menu.Attack.ToString())
        {
            SetUpgrade(attackUnlocked, attackTitles);
        }
        else if (menu == Menu.Defense.ToString())
        {
            SetUpgrade(defenseUnlocked, defenseTitles);
        }
        else if (menu == Menu.Utility.ToString())
        {
            SetUpgrade(utilityUnlocked, utilityTitles);
        }
        else if (menu == Menu.TopSecret.ToString())
        {
            SetUpgrade(topSecretUnlocked, topSecretTitles);
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
