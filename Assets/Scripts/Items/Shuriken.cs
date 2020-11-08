using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2;

    private Vector3 _shootDirection;

    public void Start()
    {
        _shootDirection = transform.right;
    }

    private void Update()
    {
        transform.position += _shootDirection * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Die();

        Destroy(gameObject);
    }
}
