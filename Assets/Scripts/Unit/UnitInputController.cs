using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInputController : MonoBehaviour
{
    protected Vector3 _movement;
    
    
    public ref Vector3 MoveDirection => ref _movement;
    
    public delegate void Attack();

    public event Attack OnAttackEvent;
    
    protected void CallOnAttackEvent() => OnAttackEvent?.Invoke();

}
