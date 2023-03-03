﻿
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerInputController : UnitInputController
    {
        private PlayerControls _controls;
        
        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.Unit.SwordAttack.performed += OnSwordAttack;
        }

        public void OnSwordAttack(InputAction.CallbackContext obj)
        {
            CallOnAttackEvent();
        }
        
        

        private void Update()
        {
            var direction = _controls.Unit.Move.ReadValue<Vector2>();
            _movement = new Vector3(direction.x, 0, direction.y);
        }

        private void OnEnable()
        {
            _controls.Unit.Enable();
        }

        
        

        private void OnDisable()
        {
            _controls.Unit.Disable();
        }

        private void OnDestroy()
        {
            _controls.Unit.SwordAttack.performed -= OnSwordAttack;
            _controls.Dispose();
        }
    }
