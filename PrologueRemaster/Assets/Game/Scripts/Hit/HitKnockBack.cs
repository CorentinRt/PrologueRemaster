using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitKnockBack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2D;

    [SerializeField] private float _knockBackAdjustment;

    private void Reset()
    {
        try
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }
        catch
        {
            Debug.LogWarning("KnockBack works with rigidBodies2D but there isn't one on this object !");
        }
    }

    public void KnockBack(Vector2 dir, float strengt)
    {
        _rb2D.AddForce(dir * strengt * _knockBackAdjustment, ForceMode2D.Impulse);
    }
}
