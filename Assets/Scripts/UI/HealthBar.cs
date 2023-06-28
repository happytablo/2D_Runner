using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if (_hearts.Count < health)
        {
            int createHealth = health - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > health)
        {
            int deleteHealth = _hearts.Count - health;
            for (int i = 0; i < deleteHealth; i++)
            {
                DeleteHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DeleteHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.DestroyHeart();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
    }
}
