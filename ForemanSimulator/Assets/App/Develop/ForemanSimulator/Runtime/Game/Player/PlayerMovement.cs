using Cysharp.Threading.Tasks;
using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using System;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Zenject;

public class PlayerMovement
{
    private const float GROUND_VELOCITY_Y = -2f;

    private readonly IInputService _inputService;
    private readonly CharacterController _controller;
    private readonly Transform _eyeTransform;
    private readonly PlayerMovementConfig _config;

    private readonly CancellationTokenSource _disposeTokenSource;

    private float _velocityY;
    private bool _isCanRun = true;

    public PlayerMovement(IInputService inputService, CharacterController controller, Transform eyeTransform, PlayerMovementConfig config)
    {
        _inputService = inputService;
        _controller = controller;
        _eyeTransform = eyeTransform;
        _config = config;

        _disposeTokenSource = new CancellationTokenSource();
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
        if (_controller.isGrounded)
        {
            _velocityY = Mathf.Sqrt(_config.jumpHeight * -2f * Physics.gravity.y);
        }
    }

    private void Move()
    {
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

        _velocityY += Physics.gravity.y * Time.deltaTime;
        _controller.Move(Vector3.up * (_velocityY * Time.deltaTime));
    }
}
