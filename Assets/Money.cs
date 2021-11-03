using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int gold;
    public static int crystals;

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

    public void GainGold(int amount)
    {
        gold += amount;
        inGameGold.GetComponentInChildren<Text>().text = $"${gold}";
        MenuGold.GetComponentInChildren<Text>().text = $"${gold}";
    }

    public void GainCrystals(int amount)
    {
        crystals += amount;
        inGameCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
        MenuCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            inGameGold.GetComponentInChildren<Text>().text = $"${gold}";
            MenuGold.GetComponentInChildren<Text>().text = $"${gold}";
            return true;
        }
        return false;
    }

    public bool SpendCrystals(int amount)
    {
        if (crystals >= amount)
        {
            crystals -= amount;
            inGameCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
            MenuCrystals.GetComponentInChildren<Text>().text = $"${crystals}";
            return true;
        }
        return false;
    }
}
