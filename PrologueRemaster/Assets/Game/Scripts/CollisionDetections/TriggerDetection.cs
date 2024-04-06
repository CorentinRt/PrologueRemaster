using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public event Action<GameObject> OnTriggerEnter;
    public event Action<GameObject> OnTriggerStay;
    public event Action<GameObject> OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            OnTriggerEnter?.Invoke(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            OnTriggerStay?.Invoke(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            OnTriggerExit?.Invoke(collision.gameObject);
        }
    }
}
