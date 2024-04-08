using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    #region Fields
    private PlayerBehavior _playerBehavior;

    [SerializeField] private InputActionReference _move;

    [SerializeField] private InputActionReference _jump;

    private Rigidbody2D _rb2D;

    private Vector2 _moveVector;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _jumpForce;

    [SerializeField] private float _jumpGravityDownForce;

    private Coroutine _jumpGravityDownCoroutine;

    private bool _isFalling;

    [SerializeField] private float _jumpBufferTimer;
    private Coroutine _jumpBufferCoroutine;

    #endregion

    public event Action OnJump;
    public event Action OnFall;
    public event Action OnStopFall;


    private void Start()
    {
        _playerBehavior = transform.parent.GetComponent<PlayerBehavior>();

        _rb2D = transform.parent.GetComponent<Rigidbody2D>();

        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;

        _jump.action.started += StartJump;
        _jump.action.canceled += StopJump;
    }
    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;

        _jump.action.started -= StartJump;
        _jump.action.canceled -= StopJump;
    }

    private void FixedUpdate()
    {
        float tempVelcityY = _rb2D.velocity.y;

        Vector2 tempVector = _rb2D.velocity;

        tempVector = _moveSpeed * _moveVector * Time.fixedDeltaTime;
        tempVector.y = tempVelcityY;

        _rb2D.velocity = tempVector;
    }
    private void Update()
    {
        if (!_playerBehavior.GroundCheck() && _rb2D.velocity.y <= 0f && !_isFalling)
        {
            _isFalling = true;
            OnFall?.Invoke();
        }
        else if (_playerBehavior.GroundCheck() && _isFalling)
        {
            _isFalling = false;
            OnStopFall?.Invoke();
        }
    }
    private void StartMove(InputAction.CallbackContext context)
    {
        
    }

    private void UpdateMove(InputAction.CallbackContext context)
    {
        _playerBehavior.SetLookDirection(context.ReadValue<Vector2>().x);

        if (!_playerBehavior.WallCheck())
        {
            _moveVector = context.ReadValue<Vector2>();
        }
        else
        {
            if (_playerBehavior.GetLookDirection() > 0f && context.ReadValue<Vector2>().x > 0f)
            {
                _moveVector = Vector2.zero;
            }
            else if (_playerBehavior.GetLookDirection() < 0f && context.ReadValue<Vector2>().x < 0f)
            {
                _moveVector = Vector2.zero;
            }
        }
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        _moveVector = Vector2.zero;
    }

    private void StartJump(InputAction.CallbackContext context)
    {
        if (_jumpBufferCoroutine != null)
        {
            StopCoroutine( _jumpBufferCoroutine );
        }

        _jumpBufferCoroutine = StartCoroutine(JumpBufferCoroutine());
    }
    private void Jump()
    {
        if (_playerBehavior.GroundCheck())
        {
            OnJump?.Invoke();
            Vector2 tempVect = _rb2D.velocity;
            tempVect.y = 0f;
            _rb2D.velocity = tempVect;
            _rb2D.AddForce(transform.TransformDirection(Vector3.up) * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void StopJump(InputAction.CallbackContext context)
    {
        if (!_playerBehavior.GroundCheck() && _jumpGravityDownCoroutine == null)
        {
            _rb2D.gravityScale = _jumpGravityDownForce;

            _jumpGravityDownCoroutine = StartCoroutine(JumpGravityDownCoroutine());
        }
    }
    private void ResetGravityDownForce()
    {
        _rb2D.gravityScale = 1f;

        StopCoroutine(_jumpGravityDownCoroutine);
        _jumpGravityDownCoroutine = null;
    }
    private IEnumerator JumpGravityDownCoroutine()
    {
        while (!_playerBehavior.GroundCheck())
        {

            yield return null;
        }

        ResetGravityDownForce();

        yield return null;
    }
    private void ResetJumpBuffer()
    {
        if (_jumpBufferCoroutine != null)
        {
            StopCoroutine(_jumpBufferCoroutine);
            _jumpBufferCoroutine = null;
        }
    }
    private IEnumerator JumpBufferCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < _jumpBufferTimer)
        {
            currentTime += Time.deltaTime;

            if (_playerBehavior.GroundCheck())
            {
                Jump();

                yield break;
            }

            yield return null;
        }

        ResetJumpBuffer();

        yield return null;
    }
}
