using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _jumpForce = 5;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _targetVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {        
        if (!Mathf.Approximately(0, _targetVelocity.x))
            transform.rotation = _targetVelocity.x > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        if (Mathf.Abs(_rigidbody.velocity.y) > 0.1f)
            _animator.SetTrigger("Jump");
    }

    private void FixedUpdate()
    {
        _rigidbody.position += new Vector2(_targetVelocity.x, 0) * Time.deltaTime * _moveSpeed ;

        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            _rigidbody.AddForce(new Vector2(0, _targetVelocity.y * _jumpForce), ForceMode2D.Impulse);
    }

    public void Move(Vector2 targetVelocity)
    {
        _targetVelocity = targetVelocity;
        _animator.SetFloat("Speed", Mathf.Abs(targetVelocity.x));
    }
}
