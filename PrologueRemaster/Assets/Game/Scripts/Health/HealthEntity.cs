using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEntity : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private bool _isDead;

    #endregion

    #region Test Function
    [Button] private void TakeDamage10() => TakeDamage(10);
    [Button] private void Heal10() => Heal(10);
    [Button] private void TestDie() => Die();

    #endregion

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        if (_isDead)
        {
            return;
        }

        _currentHealth -= value;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int value)
    {
        if (_isDead)
        {
            return;
        }

        _currentHealth += value;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }
    private void Die()
    {
        _isDead = true;
    }
}
