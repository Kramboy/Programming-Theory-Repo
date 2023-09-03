using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public event EventHandler GameOver;
    private Player player;
    private int level;
    private int playerLives;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        GameOver += MainManager_GameOver;
    }

    private void Update()
    {
        level = (int)Time.time/4;
        playerLives = player.Lives;
        if (playerLives <= 0)
        {
            playerLives = 0;
            GameOver?.Invoke(this, EventArgs.Empty);
        }
    }

    public int GetLevel()
    {
        return level;
    }
    public int GetLives()
    {
        return playerLives;
    }

    private void MainManager_GameOver(object sender, EventArgs e)
    {
        Time.timeScale = 0f;
    }
}
