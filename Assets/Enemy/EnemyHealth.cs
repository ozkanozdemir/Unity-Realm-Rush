using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] private int difficultyRamp = 1;

    private int _currentHitPoints = 0;
    private Enemy _enemy;
    private Slider _slider;


    private void OnEnable()
    {
        _currentHitPoints = maxHitPoints;        
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        
        _slider = GetComponentInChildren<Slider>();
        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        _slider.maxValue = maxHitPoints;
        _slider.value = _currentHitPoints;
    }

    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    private void ProcessHit() 
    {
        _currentHitPoints--;
        UpdateHealthSlider();

        if (_currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            _enemy.RewardGold();
        }
    }
}
