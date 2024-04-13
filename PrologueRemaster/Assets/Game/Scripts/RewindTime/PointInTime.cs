using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime
{
    #region Fields
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _angularVelocity;

    #endregion

    #region Properties
    public Vector3 Position { get => _position; set => _position = value; }
    public Quaternion Rotation { get => _rotation; set => _rotation = value; }
    public Vector3 Velocity { get => _velocity; set => _velocity = value; }
    public float AngularVelocity { get => _angularVelocity; set => _angularVelocity = value; }

    #endregion

    public PointInTime(Vector3 position, Quaternion rotation, Vector3 velocity, float angularVelocity)
    {
        _position = position;
        _rotation = rotation;
        _velocity = velocity;
        _angularVelocity = angularVelocity;
    }
}
