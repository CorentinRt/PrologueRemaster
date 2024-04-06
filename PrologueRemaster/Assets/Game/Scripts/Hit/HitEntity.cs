using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    #region Fields
    [SerializeField] private TriggerDetection _triggerDetection;

    [SerializeField] private int _damageValue;

    #endregion

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
            Damage(healthProxy.HealthEntity);
            Debug.Log("Damage to : " + healthProxy.HealthEntity.gameObject.name);
        }
    }

    private void Damage(HealthEntity entity)
    {
        entity.TakeDamage(_damageValue);
    }
}
