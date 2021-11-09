using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public Menu currentMenu = Menu.Attack;
    public static string[] attackTitles = new string[8] { "Attack Damage", "Attack Speed", "Range", "Projectile Speed", "Critical Chance", "Critical Damage", "Multishot", "Damage Per Kill" };
    public static string[] defenseTitles = new string[8] { "Health", "Regeneration", "Percentage Block", "Flat Block", "Divine Shield", "Slow Aura", "Life steal", "Health Per Kill" };
    public static string[] utilityTitles = new string[8] { "Gold Per Level", "Crystals Per Level", "Bonus Gold", "Bonus Crystals", "Attack Upgrade", "Health Upgrade", "Utility Upgrade", "Gold Interest" };
    public static string[] topSecretTitles = new string[8] { "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD", "TBD" };

    public static float[,] attackGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityGoldCost = new float[8, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretGoldCost = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }};

    public static float[,] attackGoldCostDefault = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseGoldCostDefault = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityGoldCostDefault = new float[8, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretGoldCostDefault = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

    public static float[,] attackLevels = new float[8, 2] { { 0, 999 }, { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 50 }, { 0, 50 }, { 0, 9 }, { 0, 10 } };
    public static float[,] defenseLevels = new float[8, 2] { { 0, 999 }, { 0, 999 }, { 0, 99 }, { 0, 100 }, { 0, 19 }, { 0, 25 }, { 0, 10 }, { 0, 10 } };
    public static float[,] utilityLevels = new float[8, 2] { { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 50 }, { 0, 50 }, { 0, 50 }, { 0, 10 } };
    public static float[,] topSecretLevels = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

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
                DisplayUpgradeText(title, i);
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

    public void DisplayUpgradeText(string[] title, int i)
    {
        string goldColor = "#8D9600";
        switch (title[i])
        {
            case "Attack Damage":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.attackDamage:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Attack Speed":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.attackSpeed:#.00} shots/s\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Range":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.range:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Projectile Speed":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.projectileSpeed:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Critical Chance":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.criticalChance:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Critical Damage":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.criticalDamage:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Multishot":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.multishot:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Damage Per Kill":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.damagePerKill:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;


            case "Health":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.health:#.00}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Regeneration":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.regeneration:#.00} hp/s\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Percentage Block":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.percentageBlock:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Flat Block":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.flatBlock:#.00}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Divine Shield":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.divineShield:#.00} cooldown\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Slow Aura":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.slowAura:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Life steal":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.lifeSteal:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Health Per Kill":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.healthPerKill:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;


            case "Gold Per Level":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.goldPerLevel:#.00}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Crystals Per Level":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.crystalsPerLevel:#.00}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Bonus Gold":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.bonusGold:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Bonus Crystals":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.bonusCrystals:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Attack Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.attackUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Health Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.healthUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Utility Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.utilityUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Gold Interest":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]}\n{Tower.goldInterest:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;
        }
    }

    public void ClickUpgrade(int i)
    {
        LevelUpUpgrade(i, true);
    }

    public void LevelUpUpgrade(int i, bool payForUpgrade)
    {
        bool affordUpgrade = true;
        if (currentMenu == Menu.Attack)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { attackGoldCost[i, 0], attackGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.attackDamage *= 1.1f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.2f;
                        }
                        break;
                }
                if (attackGoldCost[i, 0] >= 10)
                {
                    attackGoldCost[i, 0] /= 10;
                    attackGoldCost[i, 1] += 1;
                }
            }
            DisplayUpgradeText(attackTitles, i);
        }
    }
}