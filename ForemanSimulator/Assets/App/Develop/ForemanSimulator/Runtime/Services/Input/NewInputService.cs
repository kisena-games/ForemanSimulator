using ForemanSimulator.Runtime.Services.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IceControl.Runtime.Services.Input
{
    public class NewInputService : IInputService, PlayerInputActions.IPlayerActions, IDisposable
    {
        public event Action OnJumpAction;
        public event Action OnUseAction;
        public event Action OnAlternativeUseAction;
        public event Action OnInteractAction;

        private Vector2 _axis;
        private PlayerInputActions _actions;
        private PlayerInputActions.PlayerActions _playerMapActions;

        public Vector2 NormalizedAxis => _axis;
        public bool IsJump { get; private set; }
        public bool IsSprint { get; private set; }

        public NewInputService()
        {
            _actions = new PlayerInputActions();
            _playerMapActions = _actions.Player;
            _playerMapActions.AddCallbacks(this);
            _playerMapActions.Enable();
        }

        public void Dispose()
        {
            _playerMapActions.Disable();
            _actions.Dispose();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _axis = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            
        }

        public void OnUse(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnUseAction?.Invoke();
            }
        }

        public void OnAlternativeUse(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnAlternativeUseAction?.Invoke();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnInteractAction?.Invoke();
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnJumpAction?.Invoke();
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsSprint = true;
            }
            else if (context.canceled)
            {
                IsSprint = false;
            }
        }

        public void OnScrollSlot(InputAction.CallbackContext context)
        {
            
        }

        public void OnSelectScroll(InputAction.CallbackContext context)
        {
            
        }
    }
}