using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static float[] gold = new float[2];
    public static float[] crystals = new float[2];

    public static GameObject inGameGold;
    public static GameObject inGameCrystals;
    public static GameObject MenuGold;
    public static GameObject MenuCrystals;

    public void Init()
    {
        inGameGold = GameObject.Find("Gold");
        inGameCrystals = GameObject.Find("Crystals");
        MenuGold = GameObject.Find("MenuGold");
        MenuCrystals = GameObject.Find("MenuCrystals");
    }

    public void GainGold(float[] amount, bool gainCrystals)
    {
        if (gainCrystals)
        {
            float[] crystalGain = { amount[0], amount[1] - 2 };
            GainCrystals(crystalGain);
        }

        amount[0] *= Tower.goldValue / 100;
        if (amount[1] > gold[1] && gold[0] > amount[0])
        {
            gold[0] /= 10;
            gold[1] += 1;
        }
        while (amount[1] > gold[1])
        {
            gold[1] += 1;
        }

        gold[0] += amount[0] / Mathf.Pow(10, gold[1] - amount[1]);
        while (gold[0] >= 10)
        {
            gold[0] /= 10;
            gold[1] += 1;
        }
        DisplayGold();
    }

    public void GainCrystals(float[] amount)
    {
        amount[0] *= Tower.crystalValue / 100;
        if (amount[1] > crystals[1] && crystals[0] > amount[0])
        {
            crystals[0] /= 10;
            crystals[1] += 1;
        }
        while (amount[1] > crystals[1])
        {
            crystals[1] += 1;
        }

        crystals[0] += amount[0] / Mathf.Pow(10, crystals[1] - amount[1]);
        while (crystals[0] >= 10)
        {
            crystals[0] /= 10;
            crystals[1] += 1;
        }
        DisplayCrystals();
    }

    public bool SpendGold(float[] amount)
    {
        if (gold[1] > amount[1])
        {
            gold[0] -= amount[0] / Mathf.Pow(10, gold[1] - amount[1]);
            while (gold[0] < 1 && gold[1] >= 0)
            {
                gold[0] *= 10;
                gold[1] -= 1;
            }
            DisplayGold();
            return true;
        }
        else if (gold[1] == amount[1] && gold[0] >= amount[0])
        {
            gold[0] -= amount[0];
            while (gold[0] < 1 && gold[1] >= 0)
            {
                gold[0] *= 10;
                gold[1] -= 1;
            }
            DisplayGold();
            return true;
        }
        return false;
    }

    //public bool SpendCrystals(int amount)
    //{
    //    if (crystals >= amount)
    //    {
    //        crystals -= amount;
    //        inGameCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
    //        MenuCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
    //        return true;
    //    }
    //    return false;
    //}

    public void DisplayGold()
    {
        Mathf.Round(gold[1]);
        inGameGold.GetComponentInChildren<Text>().text = $"${GetMoneyText(gold[0], gold[1])}";
        MenuGold.GetComponentInChildren<Text>().text = $"${GetMoneyText(gold[0], gold[1])}";
    }

    public void DisplayCrystals()
    {
        Mathf.Round(crystals[1]);
        inGameCrystals.GetComponentInChildren<Text>().text = $"€{GetMoneyText(crystals[0], crystals[1])}";
        MenuCrystals.GetComponentInChildren<Text>().text = $"€{GetMoneyText(crystals[0], crystals[1])}";
    }

    public string GetMoneyText(float value, float pow)
    {
        if (pow < 6)
        {
            if (value < 1)
            {
                return $"0{value * Mathf.Pow(10, pow):#.00}";
            }
            else
            {
                return $"{value * Mathf.Pow(10, pow):#.}";
            }
        }
        return $"{value:#.00} e{pow}";
    }
}
