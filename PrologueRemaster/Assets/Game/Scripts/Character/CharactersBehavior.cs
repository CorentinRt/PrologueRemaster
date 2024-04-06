using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBehavior : MonoBehaviour
{
    #region Fields
    [Header("Move brain")]

    [SerializeField] private Transform _topWallCheck;
    [SerializeField] private Transform _botWallCheck;

    [Header("Jump brain")]

    [SerializeField] private Transform _leftGroundCheck;
    [SerializeField] private Transform _rightGroundCheck;

    [SerializeField] private LayerMask _groundLayerMask;


    #endregion

    #region Properties


    #endregion

    public bool GroundCheck()
    {
        if (Physics2D.OverlapArea(_leftGroundCheck.position, _rightGroundCheck.position, _groundLayerMask))
        {
            return true;
        }
        return false;
    }
    public bool WallCheck()
    {
        if (Physics2D.OverlapArea(_topWallCheck.position, _botWallCheck.position, _groundLayerMask))
        {
            return true;
        }
        return false;
    }

    public float GetLookDirection()
    {
        return transform.localScale.x;
    }
    public void SetLookDirection(float direction)
    {
        if (direction == 0f)
        {
            return;
        }
        if (direction > 0f)
        {
            Vector2 tempVect = new Vector2(1f, transform.localScale.y);
            transform.localScale = tempVect;
        }
        else
        {
            Vector2 tempVect = new Vector2(-1f, transform.localScale.y);
            transform.localScale = tempVect;
        }
    }
}
