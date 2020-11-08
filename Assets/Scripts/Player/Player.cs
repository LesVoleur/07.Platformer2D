using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> CoinsChanged;
    public event UnityAction Died;
    private Animator _animator;

    private int _coins;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        CoinsChanged?.Invoke(_coins);
    }

    public void Die()
    {
        if (TryGetComponent<PlayerInput>(out PlayerInput playerInput))   
            Destroy(playerInput);

        _animator.SetBool("Die", true);
        Died?.Invoke();
    }

    public void PickUpCoin()
    {
        _coins++;
        CoinsChanged?.Invoke(_coins);
    }
}
