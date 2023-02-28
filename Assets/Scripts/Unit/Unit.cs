using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Animator _animator;
    private UnitInputController _playerInputController;
    private UnitStats _unitStats;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInputController = GetComponent<UnitInputController>();
        _unitStats = GetComponent<UnitStats>();
    }


    void Update()
    {
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
}