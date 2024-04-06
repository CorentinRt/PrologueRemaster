using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour
{
    [SerializeField] private HealthEntity _healthEntity;

    public HealthEntity HealthEntity { get => _healthEntity; private set => _healthEntity = value; }

    private void Reset()
    {
        try
        {
            _healthEntity = GetComponentInParent<HealthEntity>();
        }
        catch
        {
            Debug.LogWarning("Missing the HealthEntity in parent");
        }
    }
    private void Start()
    {
        if (_healthEntity == null)
        {
            Debug.LogWarning("Connection missing between this healthProxy and healthEntity");
        }
    }
}
