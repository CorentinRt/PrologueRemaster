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

    [SerializeField] private float _invincibilityCooldown;

    private Coroutine _invincibilityCooldownCoroutine;

    private bool _isInvincible;

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
        if (_isDead || _isInvincible)
        {
            return;
        }

        StartInvincibility();

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

    #region Invincibility
    private void StartInvincibility()
    {
        if (_invincibilityCooldownCoroutine != null)
        {
            _invincibilityCooldownCoroutine = StartCoroutine(InvincibilityCooldownCoroutine());
        }
    }
    private void StopInvincibility()
    {
        if (_invincibilityCooldownCoroutine != null)
        {
            StopCoroutine( _invincibilityCooldownCoroutine);
            _invincibilityCooldownCoroutine = null;
        }
    }
    private IEnumerator InvincibilityCooldownCoroutine()
    {
        yield return new WaitForSeconds(_invincibilityCooldown);

        StopInvincibility();

        yield return null;
    }
    #endregion
}
