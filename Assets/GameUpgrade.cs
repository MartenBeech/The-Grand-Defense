using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public const int MENU_SIZE = 8;

    public enum Menu { Attack, Defense, Utility, TopSecret }
    public static Menu currentMenu = Menu.Attack;
    public static string[] attackTitles = new string[8] { "Attack Damage", "Attack Speed", "Range", "Projectile Speed", "Critical Chance", "Critical Damage", "Multishot", "Damage Per Kill" };
    public static string[] defenseTitles = new string[8] { "Health", "Regeneration", "Percentage Block", "Flat Block", "Divine Shield", "Slow Aura", "Life steal", "Health Per Kill" };
    public static string[] utilityTitles = new string[8] { "Gold Per Level", "Crystals Per Level", "Bonus Gold", "Bonus Crystals", "Attack Upgrade", "Defense Upgrade", "Utility Upgrade", "Gold Interest" };
    public static string[] topSecretTitles = new string[8] { "Start Next Wave Button", "Automatic Upgrade Attack", "Automatic Upgrade Defense", "Automatic Upgrade Utility", "Free Camera", "Speed Up Button", "Freeze Enemies", "NUKE" };

    public static float[,] attackLevels = new float[8, 2] { { 0, 999 }, { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 50 }, { 0, 50 }, { 0, 9 }, { 0, 10 } };
    public static float[,] defenseLevels = new float[8, 2] { { 0, 999 }, { 0, 999 }, { 0, 99 }, { 0, 100 }, { 0, 19 }, { 0, 40 }, { 0, 20 }, { 0, 10 } };
    public static float[,] utilityLevels = new float[8, 2] { { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 100 }, { 0, 50 }, { 0, 50 }, { 0, 50 }, { 0, 10 } };
    public static float[,] topSecretLevels = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

    public static float[,] attackGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseGoldCost = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityGoldCost = new float[8, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretGoldCost = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }};

    public static float[,] attackGoldCostDefault = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] defenseGoldCostDefault = new float[8, 2] { { 1, 1 }, { 1, 1 }, { 1, 2 }, { 1, 2 }, { 5, 3 }, { 5, 3 }, { 1, 10 }, { 1, 50 } };
    public static float[,] utilityGoldCostDefault = new float[8, 2] { { 2, 1 }, { 2, 1 }, { 1, 3 }, { 1, 3 }, { 1, 7 }, { 1, 7 }, { 1, 10 }, { 1, 50 } };
    public static float[,] topSecretGoldCostDefault = new float[8, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

    

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
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({attackLevels[i, 0]}/{attackLevels[i, 1]})</size>\n{Tower.attackDamage:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Attack Speed":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.attackSpeed:#.00} shots/s\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Range":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.range:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Projectile Speed":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.projectileSpeed:#.00}\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Critical Chance":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.criticalChance:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Critical Damage":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.criticalDamage:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Multishot":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.multishot:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;

            case "Damage Per Kill":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({attackLevels[i, 0]}/{attackLevels[i, 1]})\n{Tower.damagePerKill:#.00} %\n<color={goldColor}>{attackGoldCost[i, 0]:#.00} e{attackGoldCost[i, 1]}</color>";
                break;


            case "Health":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.health:#.00}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Regeneration":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.regeneration:#.00} hp/s\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Percentage Block":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.percentageBlock:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Flat Block":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.flatBlock:#.00}\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Divine Shield":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.divineShield:#.00} cooldown\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Slow Aura":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.slowAura:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Life steal":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.lifeSteal:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;

            case "Health Per Kill":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({defenseLevels[i, 0]}/{defenseLevels[i, 1]})\n{Tower.healthPerKill:#.00} %\n<color={goldColor}>{defenseGoldCost[i, 0]:#.00} e{defenseGoldCost[i, 1]}</color>";
                break;


            case "Gold Per Level":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.goldPerLevel:#.00}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Crystals Per Level":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.crystalsPerLevel:#.00}\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Bonus Gold":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.bonusGold:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Bonus Crystals":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.bonusCrystals:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Attack Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.attackUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Defense Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.defenseUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Utility Upgrade":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.utilityUpgrade:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
                break;

            case "Gold Interest":
                upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} ({utilityLevels[i, 0]}/{utilityLevels[i, 1]})\n{Tower.goldInterest:#.00} %\n<color={goldColor}>{utilityGoldCost[i, 0]:#.00} e{utilityGoldCost[i, 1]}</color>";
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
                    
                    case 1:
                        Tower.attackSpeed += 0.05f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.125f;
                        }
                        break;

                    case 2:
                        Tower.range += 0.5f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.15f;
                        }
                        break;

                    case 3:
                        Tower.projectileSpeed += 0.1f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 4:
                        Tower.criticalChance += 2f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.criticalDamage += 6f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.multishot += 1f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 25f;
                        }
                        break;

                    case 7:
                        Tower.damagePerKill += 0.01f;
                        if (payForUpgrade)
                        {
                            attackGoldCost[i, 0] *= 10f;
                        }
                        break;
                }
                if (attackGoldCost[i, 0] >= 10)
                {
                    attackGoldCost[i, 0] /= 10;
                    attackGoldCost[i, 1] += 1;
                }
                attackLevels[i, 0] += 1;
                if (attackLevels[i, 0] == attackLevels[i, 1])
                {
                    upgrades[0].GetComponent<Button>().enabled = false;
                }
                DisplayUpgradeText(attackTitles, i);
            }
        }

        else if (currentMenu == Menu.Defense)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { defenseGoldCost[i, 0], defenseGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.health *= 1.1f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        Tower.regeneration *= 1.1f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        Tower.percentageBlock += 1f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.3f;
                        }
                        break;

                    case 3:
                        Tower.flatBlock += 1f + defenseLevels[i, 0];
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.175f;
                        }
                        break;

                    case 4:
                        Tower.divineShield += 0.25f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.slowAura += 2f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.lifeSteal += 5f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 2f;
                        }
                        break;

                    case 7:
                        Tower.healthPerKill += 0.01f;
                        if (payForUpgrade)
                        {
                            defenseGoldCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (defenseGoldCost[i, 0] >= 10)
                {
                    defenseGoldCost[i, 0] /= 10;
                    defenseGoldCost[i, 1] += 1;
                }
            }
            DisplayUpgradeText(defenseTitles, i);
        }

        else if (currentMenu == Menu.Utility)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { utilityGoldCost[i, 0], utilityGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.goldPerLevel += 10f + (utilityLevels[i, 0] * 2f);
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        Tower.crystalsPerLevel += 1f + (utilityLevels[i, 0] * 0.2f);
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        Tower.bonusGold += 0.05f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 3:
                        Tower.bonusCrystals += 0.05f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 4:
                        Tower.attackUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.defenseUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.utilityUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 7:
                        Tower.goldInterest += 0.1f;
                        if (payForUpgrade)
                        {
                            utilityGoldCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (utilityGoldCost[i, 0] >= 10)
                {
                    utilityGoldCost[i, 0] /= 10;
                    utilityGoldCost[i, 1] += 1;
                }
            }
            DisplayUpgradeText(utilityTitles, i);
        }
    }
}