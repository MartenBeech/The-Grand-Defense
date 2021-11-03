using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    public static GameObject mainCamera;

    public void Init()
    {
        mainCamera = GameObject.Find("Main Camera");
    }
}
