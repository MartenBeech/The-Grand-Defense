using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rng : MonoBehaviour
{
    const int rngFactor = 1000;

    public int Range(int min, int max)
    {
        List<int> numbers = new List<int>();
        min *= rngFactor;
        max *= rngFactor;

        for (int i = 0; i < 50; i++)
        {
            numbers.Add(UnityEngine.Random.Range(min, max));
        }

        float number = numbers[UnityEngine.Random.Range(0, numbers.Count)];
        if (number < 0)
        {
            number += rngFactor;
        }
        float temp = number / 1000;
        return Mathf.FloorToInt(temp);
    }

    public int[] Distance(int min, int max)
    {
        int x, z;
        do
        {
            x = Range(-max, max);
            z = Range(-max, max);
        } while (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2)) < min || Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2)) > max);
        int[] pos = new int[2] { x, z };
        return pos;
    }

    public bool Chance(float percentage)
    {
        if (percentage <= 0)
        {
            return false;
        }
        if (percentage >= 100)
        {
            return true;
        }

        int chance = Range(0, 100);
        if (chance < Mathf.RoundToInt(percentage))
        {
            return true;
        }
        return false;
    }
}
