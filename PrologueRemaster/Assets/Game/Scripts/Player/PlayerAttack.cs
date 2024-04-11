using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _attack;
    
    [SerializeField] private HitEntity _hitEntity;

    [SerializeField] private float _attackDuration;
    [SerializeField] private float _attackCooldown;

    private Coroutine _attackDurationCoroutine;
    private Coroutine _attackCooldownCoroutine;

    private bool _canAttack;

    #endregion

    public event Action OnAttack1;

    private void Start()
    {
        _canAttack = true;

        _hitEntity.gameObject.SetActive(false);

        _attack.action.started += StartAttack;
    }
    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
    }

    #region Attack
    private void StartAttack(InputAction.CallbackContext context)
    {
        if (!_canAttack)
        {
            return;
        }

        OnAttack1?.Invoke();

        _canAttack = false;
        _hitEntity.gameObject.SetActive(true);

        if (_attackDurationCoroutine == null)
        {
            _attackDurationCoroutine = StartCoroutine(AttackDurationCoroutine());
        }
    }
    private void StopAttack()
    {
        if (_attackDurationCoroutine != null)
        {
            StopCoroutine(_attackDurationCoroutine);
            _attackDurationCoroutine = null;
        }

        _hitEntity.gameObject.SetActive(false);

        _attackCooldownCoroutine = StartCoroutine(AttackCooldownCoroutine());
    }
    private void ResetAttack()
    {
        if (_attackCooldownCoroutine != null)
        {
            StopCoroutine(_attackCooldownCoroutine);
            _attackCooldownCoroutine = null;
        }

        _canAttack = true;
    }
    private IEnumerator AttackDurationCoroutine()
    {
        yield return new WaitForSeconds(_attackDuration);

        StopAttack();

        yield return null;
    }
    private IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(_attackCooldown);

        ResetAttack();

        yield return null;
    }
    #endregion
}
