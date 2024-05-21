using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement :")]
    [SerializeField] private float _acceleration = 5;
    [SerializeField] private float _speed = 1;

    [Header("Dash :")]
    [SerializeField] private float _dashLenth = 5;
    [SerializeField] private float _dashDuration = 5;
    [SerializeField] private float _cooldown = 5;

    private Vector2 _inputVector;
    private Vector2 _moveAxis;
    private Rigidbody2D _rigidbody;
    private bool _isDashing = false;
    private bool _canDash = true;

    public bool IsDashing { get => _isDashing; }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!_isDashing)
            Move();
    }

    private void Move()
    {
        _moveAxis = Vector2.Lerp(_moveAxis, _inputVector, Time.deltaTime * _acceleration);
        _rigidbody.MovePosition(_rigidbody.position + (_moveAxis * _speed * Time.fixedDeltaTime));
    }

    private void Dash(Vector2 dashTarget)
    {
        _canDash = false;
        _isDashing = true;
        Vector2 startPosition = transform.position;

        DOTween.To((time) =>
        {
            Vector2 moveTarget = Vector2.Lerp(startPosition, dashTarget, time);
            _rigidbody.MovePosition(moveTarget);
        }, 0, 1, _dashDuration)
        .OnComplete(() =>
        {
            _isDashing = false;
            _inputVector = Vector2.zero;
            StartCoroutine(Cooldown(_cooldown));
        });
    }

    private void OnMove(InputValue value)
    {
        if (_isDashing)
            return;

        _inputVector = value.Get<Vector2>();
    }

    //! Faire le call dans l'update pour get les valeur d'input
    private void OnDash(InputValue value)
    {
        // print("Dash");
        if (value.Get<float>() > .5f && _canDash)
            if (_inputVector != Vector2.zero)
                Dash(transform.TransformPoint(_inputVector.normalized * _dashLenth));
    }

    private IEnumerator Cooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        _canDash = true;
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, transform.TransformPoint(_inputVector.normalized * _dashLenth));
    // }
}
