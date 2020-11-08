using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]

public class PlayerInput : MonoBehaviour
{
    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKey(KeyCode.Space))
            targetVelocity.y = 1;

        _mover.Move(targetVelocity);
    }
}
