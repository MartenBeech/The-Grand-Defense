using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
    public static GameObject tower = new GameObject();

    private void Start()
    {
        tower = GameObject.Find("Tower");
    }
}
