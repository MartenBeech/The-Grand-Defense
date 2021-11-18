using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static int level = 0;
    public static int wave = 0;
    public static float levelCounter = 0f;
    public static float waveCounter = 0f;
    public static bool inProgress = false;

    private void Update()
    {
        if (inProgress)
        {
            if (levelCounter > 0)
            {
                levelCounter -= Time.deltaTime;
                waveCounter -= Time.deltaTime;

                if (waveCounter < 0 && wave < 4)
                {
                    SendEnemies(level, wave);
                    wave++;
                    waveCounter += 3;
                }

                if (levelCounter <= 0)
                {
                    StartNextLevel();
                }
            }
        }
    }

    public void StartNextLevel()
    {
        level++;
        wave = 0;
        levelCounter = 15;
        waveCounter = 0;
    }

    public void SendEnemies(int level, int wave)
    {
        Enemy enemy = new Enemy();
        switch (level)
        {
            //case 1:
            //    switch (wave)
            //    {
            //        case 0:
            //            enemy.CreateEnemies(1, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 1:
            //            enemy.CreateEnemies(1, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 2:
            //            enemy.CreateEnemies(1, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 3:
            //            enemy.CreateEnemies(1, Enemy.Types.Normal, 5, 10);
            //            break;
            //    }
            //    break;
            //case 2:
            //    switch (wave)
            //    {
            //        case 0:
            //            enemy.CreateEnemies(2, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 1:
            //            enemy.CreateEnemies(2, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 2:
            //            enemy.CreateEnemies(2, Enemy.Types.Normal, 5, 10);
            //            break;
            //        case 3:
            //            enemy.CreateEnemies(2, Enemy.Types.Normal, 5, 10);
            //            break;
            //    }
            //    break;
            default:
                switch (wave)
                {
                    case 0:
                        enemy.CreateEnemies(3, Enemy.Types.Normal, 5, 10);
                        break;
                    case 1:
                        enemy.CreateEnemies(3, Enemy.Types.Normal, 5, 10);
                        break;
                    case 2:
                        enemy.CreateEnemies(3, Enemy.Types.Normal, 5, 10);
                        break;
                    case 3:
                        enemy.CreateEnemies(3, Enemy.Types.Normal, 5, 10);
                        break;
                }
                break;
        }
    }
}
