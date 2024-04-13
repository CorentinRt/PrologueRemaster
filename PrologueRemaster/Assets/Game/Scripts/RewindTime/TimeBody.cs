using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    #region Fields
    [SerializeField] private bool _isRewinding;

    [SerializeField] private float _recordTime;

    List<PointInTime> _pointsInTime;

    Rigidbody2D _rb;

    #endregion

    #region Methods
    public void StartRewind()
    {
        _isRewinding = true;
        _rb.isKinematic = true;
    }

    public void StopRewind()
    {
        _isRewinding = false;
        _rb.isKinematic = false;

        _rb.velocity = _pointsInTime[0].Velocity;
        _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
    }

    private void Record()
    {
        if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
        {
            _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
        }

        _pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, _rb.velocity, _rb.angularVelocity));
    }
    private void Rewind()
    {
        if (_pointsInTime.Count > 1)
        {
            PointInTime pointInTime = _pointsInTime[0];

            transform.position = pointInTime.Position;
            transform.rotation = pointInTime.Rotation;
            _pointsInTime.RemoveAt(0);
        }
        else
        {
            Debug.Log("StopRewind");
            StopRewind();
        }
    }

    #endregion

    void Start()
    {
        _pointsInTime = new List<PointInTime>();

        _rb = GetComponent<Rigidbody2D>();

        if (RewindTimeManager.Instance != null)
        {
            RewindTimeManager.Instance.OnStartRewind += StartRewind;
            RewindTimeManager.Instance.OnStopRewind += StopRewind;
        }
        else
        {
            Debug.LogWarning("You're missing the RewindTimeManager in your scene !");
        }
    }
    private void OnDestroy()
    {
        if (RewindTimeManager.Instance != null)
        {
            RewindTimeManager.Instance.OnStartRewind -= StartRewind;
            RewindTimeManager.Instance.OnStopRewind -= StopRewind;
        }
    }

    private void FixedUpdate()
    {
        if (_isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        StartRewind();
    //    }
    //    if (Input.GetKeyUp(KeyCode.T))
    //    {
    //        StopRewind();
    //    }
    //}
}
