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

    public void SetCamFromRange(float range)
    {
        float camDistance = range * 1.2f;
        mainCamera.transform.position = new Vector3(camDistance * 1.10f, camDistance * 0.9f, -camDistance * 1.10f);
    }
}
