using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public static Menu currentMenu = Menu.Attack;
    public static string[] attackTitles = new string[MENU_SIZE] { "Attack Damage", "Attack Speed", "Range", "Projectile Speed", "Critical Chance", "Critical Damage", "Multishot", "Damage Per Kill" };
    public static string[] defenseTitles = new string[MENU_SIZE] { "Health", "Regeneration", "Percentage Block", "Flat Block", "Divine Shield", "Slow Aura", "Life steal", "Health Per Kill" };
    public static string[] utilityTitles = new string[MENU_SIZE] { "Gold Per Level", "Crystals Per Level", "Gold Value", "Crystal Value", "Attack Upgrade", "Defense Upgrade", "Utility Upgrade", "Gold Interest" };
    public static string[] topSecretTitles = new string[MENU_SIZE] { "Start Next Wave Early", "Change Colors", "Automatic Upgrade Attack", "Automatic Upgrade Defense", "Automatic Upgrade Utility", "Speed Up Button", "Freeze Enemies", "NUKE" };

    public static int[] attackMaxLevels = new int[MENU_SIZE] { 999, 100, 100, 100, 50, 50, 9, 10 };
    public static int[] defenseMaxLevels = new int[MENU_SIZE] { 999, 999, 99, 100, 19, 40, 20, 10 };
    public static int[] utilityMaxLevels = new int[MENU_SIZE] { 100, 100, 100, 100, 50, 50, 50, 10 };
    public static int[] topSecretMaxLevels = new int[MENU_SIZE] { 1, 1, 1, 1, 1, 1, 1, 1 };

    public static int[] attackMenuLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] defenseMenuLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] utilityMenuLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] topSecretMenuLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };

    public static int[] attackCurrentLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] defenseCurrentLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] utilityCurrentLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] topSecretCurrentLevels = new int[MENU_SIZE] { 0, 0, 0, 0, 0, 0, 0, 0 };

    public static float[,] attackDefaultGoldCost = new float[MENU_SIZE, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseDefaultGoldCost = new float[MENU_SIZE, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityDefaultGoldCost = new float[MENU_SIZE, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretDefaultGoldCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

    public static float[,] attackCurrentGoldCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] defenseCurrentGoldCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] utilityCurrentGoldCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] topSecretCurrentGoldCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

    public static float[,] attackCurrentCrystalCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] defenseCurrentCrystalCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] utilityCurrentCrystalCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public static float[,] topSecretCurrentCrystalCost = new float[MENU_SIZE, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

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

        for (int i = 0; i < MENU_SIZE; i++)
        {
            UnlockUpgrade(attackUnlocked, i);
            UnlockUpgrade(defenseUnlocked, i);
            UnlockUpgrade(utilityUnlocked, i);
            UnlockUpgrade(topSecretUnlocked, i);
        }

        OpenMenu("Attack");

        for (int i = 0; i < MENU_SIZE; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                attackCurrentGoldCost[i, j] = attackDefaultGoldCost[i, j];
                attackCurrentCrystalCost[i, j] = attackDefaultGoldCost[i, j];
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

    public void OpenMenu(string menu)
    {
        if (menu == Menu.Attack.ToString())
        {
            SetUpgradeButtons(attackUnlocked, attackTitles);
            currentMenu = Menu.Attack;
        }
        else if (menu == Menu.Defense.ToString())
        {
            SetUpgradeButtons(defenseUnlocked, defenseTitles);
            currentMenu = Menu.Defense;
        }
        else if (menu == Menu.Utility.ToString())
        {
            SetUpgradeButtons(utilityUnlocked, utilityTitles);
            currentMenu = Menu.Utility;
        }
        else if (menu == Menu.TopSecret.ToString())
        {
            SetUpgradeButtons(topSecretUnlocked, topSecretTitles);
            currentMenu = Menu.TopSecret;
        }
    }

    public void SetUpgradeButtons(bool[] unlocked, string[] title)
    {
        GameUpgrade gameUpgrade = new GameUpgrade();
        for (int i = 0; i < MENU_SIZE; i++)
        {
            if (unlocked[i])
            {
                upgrades[i].GetComponent<Image>().enabled = true;
                upgrades[i].GetComponent<Button>().enabled = true;
                gameUpgrade.DisplayUpgradeText(title, i);
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
