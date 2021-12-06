using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgrade : MonoBehaviour
{
    public void DisplayUpgradeText(string[] title, int i)
    {
        Money money = new Money();
        UI ui = new UI();
        string goldColor = "#8D9600";
        switch (title[i])
        {
            case "Attack Damage":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackDamage, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Attack Speed":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackSpeed, true)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Range":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.range, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Projectile Speed":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.projectileSpeed, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Critical Chance":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.criticalChance, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Critical Damage":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.criticalDamage, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Multishot":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.multishot, false)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Damage Per Kill":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackMenuLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.damagePerKill, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1])}</color>";
                break;


            case "Health":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.healthMax, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Regeneration":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.regeneration, true)} hp/s\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Percentage Block":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.percentageBlock, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Flat Block":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.flatBlock, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Divine Shield":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(10 - (Tower.divineShield / 2), false)} sec cd\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Slow Aura":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.slowAura, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Life steal":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.lifeSteal, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Health Per Kill":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseMenuLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.healthPerKill, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1])}</color>";
                break;


            case "Gold Per Level":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldPerLevel, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Crystals Per Level":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.crystalsPerLevel, true)}\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Gold Value":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldValue, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Crystal Value":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.crystalValue, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Attack Upgrade":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackUpgrade, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Defense Upgrade":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.defenseUpgrade, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Utility Upgrade":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.utilityUpgrade, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;

            case "Gold Interest":
                Upgrade.menuUpgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityMenuLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldInterest, false)} %\n€<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1])}</color>";
                break;
        }
    }

    public void ClickUpgrade(int i)
    {
        LevelUpUpgrade(i, true, Upgrade.currentMenu);
    }

    public void LevelUpUpgrade(int i, bool payForUpgrade, Upgrade.Menu menu)
    {
        bool affordUpgrade = true;
        if (menu == Upgrade.Menu.Attack)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.attackCurrentCrystalCost[i, 0], Upgrade.attackCurrentCrystalCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.125f;
                        }
                        break;

                    case 2:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.15f;
                        }
                        break;

                    case 3:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 4:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 25f;
                        }
                        break;

                    case 7:
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentCrystalCost[i, 0] *= 10f;
                        }
                        break;
                }
                if (Upgrade.attackCurrentCrystalCost[i, 0] >= 10)
                {
                    Upgrade.attackCurrentCrystalCost[i, 0] /= 10;
                    Upgrade.attackCurrentCrystalCost[i, 1] += 1;
                }
                Upgrade.attackMenuLevels[i] += 1;
                if (Upgrade.attackMenuLevels[i] == Upgrade.attackMaxLevels[i])
                {
                    Upgrade.menuUpgrades[0].GetComponent<Button>().enabled = false;
                }
                if (menu == Upgrade.currentMenu)
                {
                    DisplayUpgradeText(Upgrade.attackTitles, i);
                }
            }
        }

        else if (menu == Upgrade.Menu.Defense)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.defenseCurrentCrystalCost[i, 0], Upgrade.defenseCurrentCrystalCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.3f;
                        }
                        break;

                    case 3:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.175f;
                        }
                        break;

                    case 4:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 2f;
                        }
                        break;

                    case 7:
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentCrystalCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (Upgrade.defenseCurrentCrystalCost[i, 0] >= 10)
                {
                    Upgrade.defenseCurrentCrystalCost[i, 0] /= 10;
                    Upgrade.defenseCurrentCrystalCost[i, 1] += 1;
                }
                Upgrade.defenseMenuLevels[i] += 1;
                if (Upgrade.defenseMenuLevels[i] == Upgrade.defenseMaxLevels[i])
                {
                    Upgrade.menuUpgrades[0].GetComponent<Button>().enabled = false;
                }
                if (menu == Upgrade.currentMenu)
                {
                    DisplayUpgradeText(Upgrade.defenseTitles, i);
                }
            }
        }

        else if (menu == Upgrade.Menu.Utility)
        {
            if (payForUpgrade)
            {
                Money money = new Money();
                affordUpgrade = money.SpendGold(new float[] { Upgrade.utilityCurrentCrystalCost[i, 0], Upgrade.utilityCurrentCrystalCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 3:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 4:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 7:
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentCrystalCost[i, 0] *= 25f;
                        }
                        break;
                }
                if (Upgrade.utilityCurrentCrystalCost[i, 0] >= 10)
                {
                    Upgrade.utilityCurrentCrystalCost[i, 0] /= 10;
                    Upgrade.utilityCurrentCrystalCost[i, 1] += 1;
                }
                Upgrade.utilityMenuLevels[i] += 1;
                if (Upgrade.utilityMenuLevels[i] == Upgrade.utilityMaxLevels[i])
                {
                    Upgrade.menuUpgrades[0].GetComponent<Button>().enabled = false;
                }
                if (menu == Upgrade.currentMenu)
                {
                    DisplayUpgradeText(Upgrade.utilityTitles, i);
                }
            }
        }
    }
}
