using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    #region Fields
    [SerializeField] private TriggerDetection _triggerDetection;

    [SerializeField] private int _damageValue;

    #endregion

    public event Action OnHit;

    private void Start()
    {
        _triggerDetection.OnTriggerEnter += CheckCollisionEnter;
    }
    private void OnDestroy()
    {
        _triggerDetection.OnTriggerEnter -= CheckCollisionEnter;
    }

    private void CheckCollisionEnter(GameObject gameObject)
    {
        Debug.Log("Collision");
        if (gameObject.TryGetComponent<HealthProxy>(out HealthProxy healthProxy))
        {
            OnHit?.Invoke();

            Damage(healthProxy.HealthEntity);
            Debug.Log("Damage to : " + healthProxy.HealthEntity.gameObject.name);
        }
        if (gameObject.TryGetComponent<HitKnockBackProxy>(out HitKnockBackProxy knockBackProxy))
        {
            Vector2 dir = new Vector2();
            dir.x = gameObject.transform.position.x - transform.position.x;
            dir.y = gameObject.transform.position.y - (transform.position.y - 1f);
            float strengt = dir.magnitude;
            dir = dir.normalized;
            knockBackProxy.HitKnockBack.KnockBack(dir, strengt);
            Debug.Log("KnockBack");
        }
    }

    private void Damage(HealthEntity entity)
    {
        entity.TakeDamage(_damageValue);
    }
}
