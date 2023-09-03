using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainManager : MonoBehaviour
{
    [SerializeField] private MainManager mainManager;
    [SerializeField] private Text levelText;
    [SerializeField] private Text livesText;

    private void Update()
    {
        levelText.text = $"Level {mainManager.GetLevel()}";
        livesText.text = $"Lives: {mainManager.GetLives()}";
    }
}
