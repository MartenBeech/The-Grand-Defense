using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static GameObject mainMenuCanvas;
    public static GameObject inGameCanvas;
    public static GameObject startBtn;
    public static int day = 1;

    public void Init()
    {
        mainMenuCanvas = GameObject.Find("MainMenuCanvas");
        inGameCanvas = GameObject.Find("InGameCanvas");
        startBtn = GameObject.Find("MenuStart");
    }

    public void StartGame()
    {
        mainMenuCanvas.GetComponent<Canvas>().enabled = false;
        inGameCanvas.GetComponent<Canvas>().enabled = true;
        Money.gold = new float[] { 0, 0 };
        GameLevel.level = 0;
        GameLevel.inProgress = true;
        GameLevel gameLevel = new GameLevel();
        gameLevel.StartNextLevel();
        Upgrade upgrade = new Upgrade();
        upgrade.OpenMenu(Upgrade.currentMenu.ToString());
        upgrade.ResetLevels();
        upgrade.ResetGoldCost();
        Tower tower = new Tower();
        tower.SetStats();
        Tower.healthCurrent = Tower.healthMax;
    }

    public void EndGame()
    {
        mainMenuCanvas.GetComponent<Canvas>().enabled = true;
        inGameCanvas.GetComponent<Canvas>().enabled = false;
        GameLevel.inProgress = false;
        day++;
        startBtn.GetComponentInChildren<Text>().text = $"Start Day {day}";
    }
}
