using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public static string[] attackTitles = new string[8] { "Attack Damage", "Attack Speed", "Range", "Projectile Speed", "Critical Chance", "Critical Damage", "Multishot Chance", "Damage Per Kill" };
    public static string[] defenseTitles = new string[8] { "Health", "Regeneration", "Percentage Block", "Flat Block", "Divine Shield", "Slow Aura", "Life steal", "Health Per Kill" };
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
            SetUpgradeButtons(attackUnlocked, attackTitles);
        }
        else if (menu == Menu.Defense.ToString())
        {
            SetUpgradeButtons(defenseUnlocked, defenseTitles);
        }
        else if (menu == Menu.Utility.ToString())
        {
            SetUpgradeButtons(utilityUnlocked, utilityTitles);
        }
        else if (menu == Menu.TopSecret.ToString())
        {
            SetUpgradeButtons(topSecretUnlocked, topSecretTitles);
        }
    }

    public void SetUpgradeButtons(bool[] unlocked, string[] title)
    {
        for (int i = 0; i < MENU_SIZE; i++)
        {
            if (unlocked[i])
            {
                upgrades[i].GetComponent<Image>().enabled = true;
                upgrades[i].GetComponent<Button>().enabled = true;
                upgrades[i].GetComponentInChildren<Text>().text = GetUpgradeText(title, i);
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

    public string GetUpgradeText(string[] title, int i)
    {
        string goldColor = "#8D9600";
        switch (title[i])
        {
            case "Attack Damage":
                return $"{title[i]}\n{Tower.attackDamage}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Attack Speed":
                return $"{title[i]}\n{Tower.attackSpeed} shots/s\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Range":
                return $"{title[i]}\n{Tower.range}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Projectile Speed":
                return $"{title[i]}\n{Tower.projectileSpeed}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Critical Chance":
                return $"{title[i]}\n{Tower.criticalChance} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Critical Damage":
                return $"{title[i]}\n{Tower.criticalDamage} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Multishot Chance":
                return $"{title[i]}\n{Tower.multishotChance} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";

            case "Damage Per Kill":
                return $"{title[i]}\n{Tower.damagePerKill} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";


            case "Health":
                return $"{title[i]}\n{Tower.health}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Regeneration":
                return $"{title[i]}\n{Tower.regeneration} hp/s\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Percentage Block":
                return $"{title[i]}\n{Tower.percentageBlock} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Flat Block":
                return $"{title[i]}\n{Tower.flatBlock}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Divine Shield":
                return $"{title[i]}\n{Tower.divineShield} cooldown\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Slow Aura":
                return $"{title[i]}\n{Tower.slowAura} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Life steal":
                return $"{title[i]}\n{Tower.lifeSteal} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";

            case "Health Per Kill":
                return $"{title[i]}\n{Tower.healthPerKill} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";


            case "Gold Per Level":
                return $"{title[i]}\n{Tower.goldPerLevel}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Crystals Per Level":
                return $"{title[i]}\n{Tower.crystalsPerLevel}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Bonus Gold":
                return $"{title[i]}\n{Tower.bonusGold} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Bonus Crystals":
                return $"{title[i]}\n{Tower.bonusCrystals} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Attack Upgrade":
                return $"{title[i]}\n{Tower.attackUpgrade} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Health Upgrade":
                return $"{title[i]}\n{Tower.healthUpgrade} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Utility Upgrade":
                return $"{title[i]}\n{Tower.utilityUpgrade} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";

            case "Gold Interest":
                return $"{title[i]}\n{Tower.goldInterest} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
        }
        return "";
    }

    public void LevelUpUpgrade()
    {

    }
}