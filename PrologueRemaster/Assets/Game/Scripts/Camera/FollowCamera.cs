using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _followObject;

    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;

    private void OnValidate()
    {
        if (_followObject != null)
        {
            transform.position = _followObject.transform.position + new Vector3(_xOffset, _yOffset);
        }
    }
    private void Update()
    {
        float tempDir = 1f;
        if (_followObject.transform.localScale.x < 0f)
        {
            tempDir = -1f;
        }
        transform.position = _followObject.transform.position + new Vector3(_xOffset * tempDir, _yOffset);
    }
}
