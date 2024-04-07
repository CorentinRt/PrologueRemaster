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
    }
    private void OnDestroy()
    {
        if (_healthEntity != null)
        {
            _healthEntity.OnTakeDamage -= PlayTakeDamageAnim;
            _healthEntity.OnTakeHeal -= PlayTakeHealAnim;
            _healthEntity.OnDie -= PlayDeathAnim;
        }
    }

    public void PlayAttack1Anim()
    {

    }

    public void PlayJumpAnim()
    {

    }
    public void PlayFallAnim()
    {

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
        _animator.SetTrigger("die");
    }
}
