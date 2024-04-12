using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitKnockBackProxy : MonoBehaviour
{
    [SerializeField] private HitKnockBack _hitKnockBack;

    public HitKnockBack HitKnockBack { get => _hitKnockBack; private set => _hitKnockBack = value; }

    private void Reset()
    {
		try
		{
			_hitKnockBack = GetComponentInParent<HitKnockBack>();
		}
		catch
		{
			Debug.LogWarning("Missing a HitKnockBack with this hitKnockbackProxy !");
		}
    }
}
