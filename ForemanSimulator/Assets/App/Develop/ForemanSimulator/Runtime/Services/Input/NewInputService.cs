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
        public event Action OnMainInventoryAction;

        private Vector2 _axis;
        private PlayerInputActions _actions;
        private PlayerInputActions.PlayerActions _playerMapActions;

        private bool _isLock = false;

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
            if (!_isLock)
            {
                _axis = context.ReadValue<Vector2>();
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            
        }

        public void OnUse(InputAction.CallbackContext context)
        {
            if (context.performed && !_isLock)
            {
                OnUseAction?.Invoke();
            }
        }

        public void OnAlternativeUse(InputAction.CallbackContext context)
        {
            if (context.performed && !_isLock)
            {
                OnAlternativeUseAction?.Invoke();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed && !_isLock)
            {
                OnInteractAction?.Invoke();
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && !_isLock)
            {
                OnJumpAction?.Invoke();
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed && !_isLock)
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

        public void OnMainInventory(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMainInventoryAction?.Invoke();
            }
        }

        public void Lock(bool isNeedToLock)
        {
            _isLock = isNeedToLock;

            if (_isLock)
            {
                _axis = Vector2.zero;
            }

            Cursor.lockState = _isLock ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = _isLock;
        }
    }
}