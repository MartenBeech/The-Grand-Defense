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
        UI ui = new UI();
        string goldColor = "#8D9600";
        switch (title[i])
        {
            case "Attack Damage":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackDamage, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Attack Speed":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackSpeed, true)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Range":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.range, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Projectile Speed":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.projectileSpeed, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Critical Chance":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.criticalChance, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Critical Damage":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.criticalDamage, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Multishot":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.multishot, false)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;

            case "Damage Per Kill":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.attackCurrentLevels[i]}/{Upgrade.attackMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.damagePerKill, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.attackCurrentGoldCost[i, 0], Upgrade.attackCurrentGoldCost[i, 1])}</color>";
                break;


            case "Health":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.healthMax, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Regeneration":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.regeneration, true)} hp/s\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Percentage Block":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.percentageBlock, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Flat Block":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.flatBlock, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Divine Shield":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(10 - (Tower.divineShield / 2), false)} sec cd\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Slow Aura":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.slowAura, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Life steal":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.lifeSteal, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;

            case "Health Per Kill":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.defenseCurrentLevels[i]}/{Upgrade.defenseMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.healthPerKill, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1])}</color>";
                break;


            case "Gold Per Level":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldPerLevel, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Crystals Per Level":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.crystalsPerLevel, true)}\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Gold Value":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldValue, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Crystal Value":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.crystalValue, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Attack Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.attackUpgrade, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Defense Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.defenseUpgrade, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Utility Upgrade":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.utilityUpgrade, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;

            case "Gold Interest":
                Upgrade.upgrades[i].GetComponentInChildren<Text>().text = $"{title[i]} <size=10>({Upgrade.utilityCurrentLevels[i]}/{Upgrade.utilityMaxLevels[i]})</size>\n{ui.GetNumberText(Tower.goldInterest, false)} %\n$<color={goldColor}>{money.GetMoneyText(Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1])}</color>";
                break;
        }
    }

    public void ClickUpgrade(int i)
    {
        LevelUpUpgrade(i, true, Upgrade.currentMenu);
    }

    public void LevelUpUpgrade(int i, bool payForUpgrade, Upgrade.Menu menu)
    {
        Tower tower = new Tower();
        bool affordUpgrade = true;
        if (menu == Upgrade.Menu.Attack)
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
                        tower.SetAttackDamage();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;
                    
                    case 1:
                        tower.SetAttackSpeed();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.125f;
                        }
                        break;

                    case 2:
                        tower.SetRange();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.15f;
                        }
                        break;

                    case 3:
                        tower.SetProjectileSpeed();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 4:
                        tower.SetCriticalChance();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        tower.SetCriticalDamage();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        tower.SetMultishot();
                        if (payForUpgrade)
                        {
                            Upgrade.attackCurrentGoldCost[i, 0] *= 25f;
                        }
                        break;

                    case 7:
                        tower.SetDamagePerKill();
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
                affordUpgrade = money.SpendGold(new float[] { Upgrade.defenseCurrentGoldCost[i, 0], Upgrade.defenseCurrentGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        tower.SetHealth();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        tower.SetRegeneration();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        tower.SetPercentageBlock();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.3f;
                        }
                        break;

                    case 3:
                        tower.SetFlatBlock();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.175f;
                        }
                        break;

                    case 4:
                        tower.SetDivineShield();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        tower.SetSlowAura();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        tower.SetLifeSteal();
                        if (payForUpgrade)
                        {
                            Upgrade.defenseCurrentGoldCost[i, 0] *= 2f;
                        }
                        break;

                    case 7:
                        tower.SetHealthPerKill();
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
                Upgrade.defenseCurrentLevels[i] += 1;
                if (Upgrade.defenseCurrentLevels[i] == Upgrade.defenseMaxLevels[i])
                {
                    Upgrade.upgrades[0].GetComponent<Button>().enabled = false;
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
                affordUpgrade = money.SpendGold(new float[] { Upgrade.utilityCurrentGoldCost[i, 0], Upgrade.utilityCurrentGoldCost[i, 1] });
            }
            if (affordUpgrade)
            {
                switch (i)
                {
                    case 0:
                        tower.SetGoldPerLevel();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 1:
                        tower.SetCrystalsPerLevel();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 2:
                        tower.SetGoldValue();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 3:
                        tower.SetCrystalValue();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.2f;
                        }
                        break;

                    case 4:
                        tower.SetAttackUpgrade();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 5:
                        tower.SetDefenseUpgrade();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 6:
                        tower.SetUtilityUpgrade();
                        if (payForUpgrade)
                        {
                            Upgrade.utilityCurrentGoldCost[i, 0] *= 1.1f;
                        }
                        break;

                    case 7:
                        tower.SetGoldInterest();
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
                Upgrade.utilityCurrentLevels[i] += 1;
                if (Upgrade.utilityCurrentLevels[i] == Upgrade.utilityMaxLevels[i])
                {
                    Upgrade.upgrades[0].GetComponent<Button>().enabled = false;
                }
                if (menu == Upgrade.currentMenu)
                {
                    DisplayUpgradeText(Upgrade.utilityTitles, i);
                }
            }
        }
    }

    public void LevelUpRandomAttack()
    {
        List<int> indexes = new List<int>();

        for (int i = 0; i < Upgrade.UPGRADE_SIZE; i++)
        {
            if (Upgrade.attackUnlocked[i])
            {
                indexes.Add(i);
            }
        }

        Rng rng = new Rng();
        int rnd = rng.Range(0, indexes.Count);

        LevelUpUpgrade(indexes[rnd], false, Upgrade.Menu.Attack);
    }

    public void LevelUpRandomDefense()
    {
        List<int> indexes = new List<int>();

        for (int i = 0; i < Upgrade.UPGRADE_SIZE; i++)
        {
            if (Upgrade.defenseUnlocked[i])
            {
                indexes.Add(i);
            }
        }

        Rng rng = new Rng();
        int rnd = rng.Range(0, indexes.Count);

        LevelUpUpgrade(indexes[rnd], false, Upgrade.Menu.Defense);
    }

    public void LevelUpRandomUtility()
    {
        List<int> indexes = new List<int>();

        for (int i = 0; i < Upgrade.UPGRADE_SIZE; i++)
        {
            if (Upgrade.utilityUnlocked[i])
            {
                indexes.Add(i);
            }
        }

        Rng rng = new Rng();
        int rnd = rng.Range(0, indexes.Count);

        LevelUpUpgrade(indexes[rnd], false, Upgrade.Menu.Utility);
    }
}