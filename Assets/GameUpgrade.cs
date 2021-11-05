using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public static string[] attackTitles = new string[8] { "Attack Damage", "Attack Speed", "Range", "Projectile Speed", "Critical Chance", "Critical Damage", "Multishot", "Damage Per Kill" };
    public static string[] defenseTitles = new string[8] { "Health", "Regeneration", "Resistance", "Flat block", "Divine Shield", "Slow Aura", "Life steal", "Health Per Kill" };
    public static string[] utilityTitles = new string[8] { "Gold Per Level", "Crystals Per Level", "Bonus Gold", "Bonus Crystals", "Attack Upgrade", "Health Upgrade", "Utility Upgrade", "Gold Interest" };
    public static string[] topSecretTitles = new string[8] { "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD" };

    public static float[,] attackGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityGoldCost = new float[8, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretGoldCost = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }};

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
            SetUpgrade(attackUnlocked, attackTitles, attackGoldCost);
        }
        else if (menu == Menu.Defense.ToString())
        {
            SetUpgrade(defenseUnlocked, defenseTitles, defenseGoldCost);
        }
        else if (menu == Menu.Utility.ToString())
        {
            SetUpgrade(utilityUnlocked, utilityTitles, utilityGoldCost);
        }
        else if (menu == Menu.TopSecret.ToString())
        {
            SetUpgrade(topSecretUnlocked, topSecretTitles, topSecretGoldCost);
        }
    }

    public void SetUpgrade(bool[] unlocked, string[] title, float[,] cost)
    {
        for (int i = 0; i < MENU_SIZE; i++)
        {
            if (unlocked[i])
            {
                upgrades[i].GetComponent<Image>().enabled = true;
                upgrades[i].GetComponent<Button>().enabled = true;
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{cost[i, 0].ToString("#.00")} e{cost[i, 1]}";
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
