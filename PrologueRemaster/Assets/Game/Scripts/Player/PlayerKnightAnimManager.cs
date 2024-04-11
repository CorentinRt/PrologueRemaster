using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnightAnimManager : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private PlayerMovements _movements;

    [SerializeField] private HealthEntity _healthEntity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        if (_healthEntity != null)
        {
            _healthEntity.OnTakeDamage += PlayTakeDamageAnim;
            _healthEntity.OnTakeHeal += PlayTakeHealAnim;
            _healthEntity.OnDie += PlayDeathAnim;
        }
        if (_movements != null)
        {
            _movements.OnStartMove += StartRunAnim;
            _movements.OnStopMove += StopRunAnim;

            _movements.OnJump += PlayJumpAnim;

            _movements.OnFall += PlayFallAnim;
            _movements.OnStopFall += StopFallAnim;
        }
    }
    private void OnDestroy()
    {
        if (_healthEntity != null)
        {
            _healthEntity.OnTakeDamage -= PlayTakeDamageAnim;
            _healthEntity.OnTakeHeal -= PlayTakeHealAnim;
            _healthEntity.OnDie -= PlayDeathAnim;
        }
        if (_movements != null)
        {
            _movements.OnStartMove -= StartRunAnim;
            _movements.OnStopMove -= StopRunAnim;

            _movements.OnJump -= PlayJumpAnim;

            _movements.OnFall -= PlayFallAnim;
            _movements.OnStopFall -= StopFallAnim;
        }
    }

    public void PlayAttack1Anim()
    {
        
    }

    public void StartRunAnim()
    {
        _animator.SetBool("isRunning", true);
    }
    public void StopRunAnim()
    {
        _animator.SetBool("isRunning", false);
    }
    public void PlayJumpAnim()
    {
        _animator.SetTrigger("jump");
    }
    public void PlayFallAnim()
    {
        _animator.SetBool("isFalling", true);
    }
    public void StopFallAnim()
    {
        _animator.SetBool("isFalling", false);
    }
    public void PlayTakeDamageAnim()
    {
        _animator.SetTrigger("takeDamage");
    }
    public void PlayTakeHealAnim()
    {

    }
    public void PlayDeathAnim()
    {
        _animator.SetTrigger("isDead");
    }
}
