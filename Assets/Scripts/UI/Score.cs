using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int value)
    {
        _scoreText.text = value.ToString();
    }
}
