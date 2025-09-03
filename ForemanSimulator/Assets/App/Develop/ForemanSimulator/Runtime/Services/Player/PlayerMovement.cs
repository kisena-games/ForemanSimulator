using System;
using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using System.Threading;
using Infrastructure.EventBus;
using Infrastructure.EventBus.Signals;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Services.Player
{
    public class PlayerMovement : IInitializable, IDisposable
    {
        private const float GROUND_VELOCITY_Y = -2f;

        private CinemachineCamera _cinemachineCamera;
        private IInputService _inputService;
        private CharacterController _controller;
        private Transform _eyeTransform;
        private PlayerMovementConfig _config;

        private readonly CancellationTokenSource _cts = new();

        private float _velocityY;
        private bool _isCanRun = true;
        private bool _isMovementLocked = false;
        private bool _isJumpLocked = false;
        private EventBus _eventBus;

        [Inject]
        private void Construct(IInputService inputService, 
            CharacterController controller,
            CinemachineCamera camera,
            PlayerMovementConfig mConfig,
            EventBus eventBus)
        {
            _inputService = inputService;
            _controller = controller;
            _cinemachineCamera = camera;
            _config = mConfig;
            _eventBus = eventBus;
        }
        
        public void Initialize()
        {
            _eyeTransform = _cinemachineCamera.transform;
            _eventBus.Subscribe<InventoryActionSignal>(LockMovement, 0);
        }

        public void Update()
        {
            Move();
            Gravity();
        }
        

        public void DisableSprint(bool isDisable)
        {
            _isCanRun = !isDisable;
        }

        public void Jump()
        {
            if (_isJumpLocked) return;
            
            if (_controller.isGrounded)
            {
                _velocityY = Mathf.Sqrt(_config.jumpHeight * -2f * _config.gravityForce);
            }
        }

        private void LockMovement(InventoryActionSignal signal)
        {
            _isMovementLocked = signal.NeedToLock;
            _isJumpLocked = signal.NeedToLock;
        }
        
        private void Move()
        {
            if (_isMovementLocked) return;
            
            Vector2 inputDirection = _inputService.NormalizedAxis;

            if (inputDirection != Vector2.zero)
            {
                Vector3 moveForward = inputDirection.y * _eyeTransform.forward;
                Vector3 moveRight = inputDirection.x * _eyeTransform.right;
                moveForward.y = 0;
                moveRight.y = 0;

                Vector3 moveDirection = (moveForward + moveRight).normalized * Time.deltaTime;

                float moveSpeed = _inputService.IsSprint && _isCanRun ? _config.sprintSpeed : _config.walkSpeed;
                moveDirection *= moveSpeed;

                _controller.Move(moveDirection);
            }
        }

        private void Gravity()
        {
            if (_controller.isGrounded && _velocityY < 0)
            {
                _velocityY = GROUND_VELOCITY_Y;
            }

            _velocityY += _config.gravityForce * Time.deltaTime;
            _controller.Move(Vector3.up * (_velocityY * Time.deltaTime));
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<InventoryActionSignal>(LockMovement);
        }
    }
}
