using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Mover))]

public class EnemyAI : MonoBehaviour
{
    private Enemy _enemy;
    private Mover _mover;
    private int _destination;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _mover = GetComponent<Mover>();
        _destination = 1;    
    }

    private void Update()
    {
        Vector2 targetVelocity = new Vector2(_destination, 0);
        _mover.Move(targetVelocity);
        
        Vector2 startRay = new Vector2(transform.position.x + _destination, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startRay, targetVelocity);

        if (hit)
            if (hit.collider.TryGetComponent(out Player player))
                _enemy.TryAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurnWaypoint turnWaypoint))
            _destination *= -1;
    }
}
