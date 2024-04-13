using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RewindTimeManager : MonoBehaviour
{
    #region Singleton Setup
    private static RewindTimeManager _instance;
    public static RewindTimeManager Instance { get => _instance; set => _instance = value; }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }
        _instance = this;
    }
    #endregion

    [SerializeField] private InputActionReference _rewindTime;

    [SerializeField] private bool _useRewind;

    public event Action OnStartRewind;
    public event Action OnStopRewind;

    private void Start()
    {
        _rewindTime.action.started += StartRewindAll;
        _rewindTime.action.canceled += StopRewindAll;
    }
    private void OnDestroy()
    {
        _rewindTime.action.started -= StartRewindAll;
        _rewindTime.action.canceled -= StopRewindAll;
    }

    private void StartRewindAll(InputAction.CallbackContext context)
    {
        if (_useRewind)
        {
            OnStartRewind?.Invoke();
        }
    }
    private void StopRewindAll(InputAction.CallbackContext context)
    {
        if (_useRewind)
        {
            OnStopRewind?.Invoke();
        }
    }
}
