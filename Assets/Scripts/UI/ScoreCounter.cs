using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreAmount;
    [SerializeField] private int _interval;

    public event UnityAction<int> ScoreChanged;
    private int _score;

    private void Start()
    {
        StartCoroutine(AddScoreRoutine());
    }

    private IEnumerator AddScoreRoutine()
    {
        var waitForSeconds = new WaitForSeconds(_interval);
        while(true)
        {
            yield return waitForSeconds;
            AddScore(_scoreAmount);
        }
    }

    private void AddScore(int scoreAmount)
    {
        _score += scoreAmount;
        ScoreChanged?.Invoke(_score);
    }
}