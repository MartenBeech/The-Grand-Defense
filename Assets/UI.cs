using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public void DisplayHealthBar()
    {
        GameObject healthBar = GameObject.Find("HealthBar");
        healthBar.GetComponentInChildren<Text>().text = $"{Tower.healthCurrent:#.00} / {Tower.healthMax:#.00}";
        SetHealthBarColor();
    }

    public void SetHealthBarColor()
    {
        GameObject healthBar = GameObject.Find("HealthBar");

        if (Tower.shielded)
        {
            healthBar.GetComponent<Image>().color = Color.HSVToRGB(180 / 360f, 1f, 1f);
        }
        else
        {
            healthBar.GetComponent<Image>().color = Color.HSVToRGB((Tower.healthCurrent / Tower.healthMax) * 120 / 360, 1f, 1f);
        }
    }

    public string GetNumberText(float number, bool twoDecimals)
    {
        string text;
        if (number == 0)
        {
            return "0";
        }
        if (number < 100 && twoDecimals)
        {
            text = $"{number:#.00}";
        }
        else
        {
            text = $"{number:#.}";
        }
        return text;
    }
}
