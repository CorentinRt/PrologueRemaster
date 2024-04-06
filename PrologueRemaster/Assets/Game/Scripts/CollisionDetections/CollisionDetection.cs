using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public event Action<GameObject> OnCollisionEnter;
    public event Action<GameObject> OnCollisionStay;
    public event Action<GameObject> OnCollisionExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            OnCollisionEnter?.Invoke(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            OnCollisionStay?.Invoke(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            OnCollisionExit?.Invoke(collision.gameObject);
        }
    }
}
