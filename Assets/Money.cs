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

    public void GainGold(float[] amount)
    {
        gold[1] += amount[1];
        gold[0] += amount[0] / Mathf.Pow(10, gold[1] - amount[1]);
        if (gold[0] >= 10)
        {
            gold[0] /= 10;
            gold[1] += 1;
        }
        DisplayGold();
    }

    public void GainCrystals(float[] amount)
    {
        crystals[1] += amount[1];
        crystals[0] += amount[0] / Mathf.Pow(10, crystals[1] - amount[1]);
        if (crystals[0] >= 10)
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
            while (gold[0] < 1)
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
            while (gold[0] < 1)
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
        inGameGold.GetComponentInChildren<Text>().text = $"${gold[0].ToString("#.00")} e{gold[1]}";
        MenuGold.GetComponentInChildren<Text>().text = $"${gold[0].ToString("#.00")} e{gold[1]}";
    }

    public void DisplayCrystals()
    {
        Mathf.Round(crystals[1]);
        inGameGold.GetComponentInChildren<Text>().text = $"${crystals[0].ToString("#.00")} e{crystals[1]}";
        MenuGold.GetComponentInChildren<Text>().text = $"${crystals[0].ToString("#.00")} e{crystals[1]}";
    }
}
