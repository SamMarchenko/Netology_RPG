using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Animator _animator;
    private UnitInputController _playerInputController;
    private UnitStats _unitStats;
    private bool _inAnimation;
    public bool InAnimation => _inAnimation;


    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInputController = GetComponent<UnitInputController>();
        _unitStats = GetComponent<UnitStats>();

        _playerInputController.OnAttackEvent += OnAttack;
    }


    private void OnAttack()
    {
        if (_inAnimation)
        {
            return;
        }

        _inAnimation = true;
        _animator.SetTrigger("SwordAttack");
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_inAnimation)
        {
            return;
        }

        ref var movement = ref _playerInputController.MoveDirection;

        _animator.SetFloat("ForwardMove", movement.z);
        _animator.SetFloat("SideMove", movement.x);

        if (movement.x == 0 && movement.z == 0)
        {
            _animator.SetBool("Moving", false);
        }
        else
        {
            _animator.SetBool("Moving", true);
            transform.position += movement * Time.deltaTime * _unitStats.MoveSpeed;
        }
    }

    //вызывается в конце анимации атаки мечем
    public void EndAnimation()
    {
        _inAnimation = false;
    }
}