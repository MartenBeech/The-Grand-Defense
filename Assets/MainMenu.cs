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
        Money.gold = 0;
        Game.level = 0;
        Game.inProgress = true;
        Game gameLevel = new Game();
        gameLevel.StartNextLevel();
    }

    public void EndGame()
    {
        mainMenuCanvas.GetComponent<Canvas>().enabled = true;
        inGameCanvas.GetComponent<Canvas>().enabled = false;
        Game.inProgress = false;
        day++;
        startBtn.GetComponentInChildren<Text>().text = $"Start Day {day}";
    }
}
