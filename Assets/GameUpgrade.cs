using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrade : MonoBehaviour
{
    public void DisplayUpgradeText(string[] title, int i)
    {
        Money money = new Money();
        string goldColor = "#8D9600";
        switch (title[i])
        {
            case "Attack Damage":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.attackDamage:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Attack Speed":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.attackSpeed * 100:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Range":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.range:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Projectile Speed":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.projectileSpeed:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Critical Chance":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.criticalChance:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Critical Damage":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.criticalDamage:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Multishot":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.multishot:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Damage Per Kill":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{Tower.damagePerKill:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;


            case "Health":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.health:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Regeneration":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.regeneration:#.00} hp/s\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Percentage Block":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.percentageBlock:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Flat Block":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.flatBlock:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Divine Shield":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.divineShield:#.00} cooldown\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Slow Aura":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.slowAura:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Life steal":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.lifeSteal:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Health Per Kill":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{Tower.healthPerKill:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;


            case "Gold Per Level":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.goldPerLevel:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Crystals Per Level":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.crystalsPerLevel:#.00}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Bonus Gold":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.bonusGold:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Bonus Crystals":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.bonusCrystals:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Attack Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.attackUpgrade:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Defense Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.defenseUpgrade:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Utility Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.utilityUpgrade:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Gold Interest":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{Tower.goldInterest:#.} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
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
        if (Upgrade.currentMenu == Upgrade.Menu.Attack)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.attackDamage *= 1.1f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;
                    
                    case 1:
                        Tower.attackSpeed += 0.05f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.125f;
                        }
                        break;

                    case 2:
                        Tower.range += 0.5f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.15f;
                        }
                        break;

                    case 3:
                        Tower.projectileSpeed += 0.1f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 4:
                        Tower.criticalChance += 2f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.criticalDamage += 6f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.multishot += 1f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 25f;
                        }
                        break;

                    case 7:
                        Tower.damagePerKill += 0.01f;
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 10f;
                        }
                        break;
                }
                if (Upgrade.attackCurrentGoldCost[i, 0] >= 10)
                {
                    Upgrade.attackCurrentGoldCost[i, 0] /= 10;
                    Upgrade.attackCurrentGoldCost[i, 1] += 1;
                }
                Upgrade.attackCurrentLevels[i] += 1;
                if (Upgrade.attackCurrentLevels[i] == Upgrade.attackMaxLevels[i])
                {
                    Upgrade.upgrades[0].GetComponent<Button>().enabled = false;
                }
                DisplayUpgradeText(Upgrade.attackTitles, i);
            }
        }

        else if (Upgrade.currentMenu == Upgrade.Menu.Defense)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.health *= 1.1f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        Tower.regeneration *= 1.1f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        Tower.percentageBlock += 1f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.3f;
                        }
                        break;

                    case 3:
                        Tower.flatBlock += 1f + Upgrade.defenseCurrentLevels[i];
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.175f;
                        }
                        break;

                    case 4:
                        Tower.divineShield += 0.25f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.slowAura += 2f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.lifeSteal += 5f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 2f;
                        }
                        break;

                    case 7:
                        Tower.healthPerKill += 0.01f;
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (Upgrade.defenseCurrentGoldCost[i, 0] >= 10)
                {
                    Upgrade.defenseCurrentGoldCost[i, 0] /= 10;
                    Upgrade.defenseCurrentGoldCost[i, 1] += 1;
                }
            }
            DisplayUpgradeText(Upgrade.defenseTitles, i);
        }

        else if (Upgrade.currentMenu == Upgrade.Menu.Utility)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        Tower.goldPerLevel += 10f + (Upgrade.utilityCurrentLevels[i] * 2f);
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        Tower.crystalsPerLevel += 1f + (Upgrade.utilityCurrentLevels[i] * 0.2f);
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        Tower.bonusGold += 0.05f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 3:
                        Tower.bonusCrystals += 0.05f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 4:
                        Tower.attackUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        Tower.defenseUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        Tower.utilityUpgrade += 0.02f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 7:
                        Tower.goldInterest += 0.1f;
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (Upgrade.utilityCurrentGoldCost[i, 0] >= 10)
                {
                    Upgrade.utilityCurrentGoldCost[i, 0] /= 10;
                    Upgrade.utilityCurrentGoldCost[i, 1] += 1;
                }
            }
            DisplayUpgradeText(Upgrade.utilityTitles, i);
        }
    }
}