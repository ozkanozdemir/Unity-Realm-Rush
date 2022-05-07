using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credentials : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeScoreText;

    private GameSession _gameSession;

    private void Awake()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        if (timeScoreText != null && _gameSession != null)
        {
            var timing = _gameSession.Timing;
            var seconds = TimeSpan.FromSeconds(timing).Seconds;
            var minutes = TimeSpan.FromSeconds(timing).Minutes;
            
            timeScoreText.text = "Time Score = ";

            if (minutes < 10)
            {
                timeScoreText.text += "0" + minutes;
            }
            else
            {
                timeScoreText.text += minutes;
            }
            
            timeScoreText.text += ":";
            
            if (seconds < 10)
            {
                timeScoreText.text += "0" + seconds;
            }
            else
            {
                timeScoreText.text += seconds;
            }
        }
    }

    public void RestartGame()
    {
        if (_gameSession != null)
        {
            _gameSession.StartGame();   
        }
    }
}
