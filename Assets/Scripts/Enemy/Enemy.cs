using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _shurikenPrefab;

    private GameObject _shuriken;
    private ShurikenPoint _shurikenPoint;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _shurikenPoint = GetComponentInChildren<ShurikenPoint>();
    }

    public void TryAttack()
    {
        if (_shuriken == null)
        {       
            _animator.SetTrigger("Attack");
            _shuriken = Instantiate(_shurikenPrefab, _shurikenPoint.transform.position, _shurikenPoint.transform.rotation);
        }
    }
}
