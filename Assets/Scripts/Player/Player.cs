using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    public event UnityAction<int> HealthChanged;
    public event UnityAction _died;

    private int _score;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _died?.Invoke();
    }
}
