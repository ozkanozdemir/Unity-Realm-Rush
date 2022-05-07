using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private TextMeshProUGUI _timingText;
    private float _timing;
    
    public float Timing { get { return _timing;  } }

    private void Awake()
    {
        var numGameSessions = FindObjectsOfType<GameSession>().Length;
        
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        _timing += Time.deltaTime;
    }

    public void StartGame()
    {
        _timing = 0f;
        SceneManager.LoadScene("Game");
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("Credentials");
    }
}
