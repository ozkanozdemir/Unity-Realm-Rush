using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance;
    [SerializeField] private TextMeshProUGUI displayBalance;
    [SerializeField] private TextMeshProUGUI timeText;

    private GameSession _gameSession;
    
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();

        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (timeText != null && _gameSession != null)
        {
            var timing = _gameSession.Timing;
            var seconds = TimeSpan.FromSeconds(timing).Seconds;
            var minutes = TimeSpan.FromSeconds(timing).Minutes;
            
            timeText.text = "Time = ";

            if (minutes < 10)
            {
                timeText.text += "0" + minutes;
            }
            else
            {
                timeText.text += minutes;
            }
            
            timeText.text += ":";
            
            if (seconds < 10)
            {
                timeText.text += "0" + seconds;
            }
            else
            {
                timeText.text += seconds;
            }
        }
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            //Lose the game;
            _gameSession.GameOver();
        }
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
