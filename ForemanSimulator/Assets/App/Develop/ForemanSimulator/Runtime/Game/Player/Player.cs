using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using ForemanSimulator.Runtime.Services.Inventory;
using System;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _camera;
        [SerializeField] private PlayerMovementConfig _movementConfig;
        [SerializeField] private PlayerStaminaConfig _staminaConfig;
        [SerializeField] private LayerMask _interactMask;

        [SerializeField] private QuickAccessInventoryView _quickAccessInventoryView;
        [SerializeField] private MainInventoryView _mainInventoryView;

        private const int QUICK_ACCESS_INVENTORY_SIZE = 9;

        private IInputService _inputService;

        private PlayerMovement _movement;
        private PlayerStamina _stamina;
        private PlayerInteract _interact;
        private QuickAccessInventory _quickAccessInventory;
        private MainInventory _mainInventory;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            Initialize();
        }

        public void Initialize()
        {
            InitializePlayerMovement();
            InitializePlayerStamina();
            InitializeInteract();
            InitializeInventories();
        }

        private void InitializePlayerMovement()
        {
            CharacterController characterController = GetComponent<CharacterController>();
            _movement = new PlayerMovement(_inputService, characterController, _camera.transform, _movementConfig);
            _inputService.OnJumpAction += _movement.Jump;
        }

        private void InitializePlayerStamina()
        {
            _stamina = new PlayerStamina(_inputService, _staminaConfig);
            _stamina.OnEmptyStamina += _movement.DisableSprint;
        }

        private void InitializeInteract()
        {
            _interact = new PlayerInteract(Camera.main, _interactMask);
            _inputService.OnInteractAction += _interact.Interact;
        }

        private void InitializeInventories()
        {
            //_quickAccessInventory = new QuickAccessInventory(QUICK_ACCESS_INVENTORY_SIZE);
            //_mainInventory = new MainInventory(3, 5);
        }

        private void Update()
        {
            _movement.Update();
            _stamina.Update();
        }

        private void OnDestroy()
        {
            _inputService.OnJumpAction -= _movement.Jump;
            _stamina.OnEmptyStamina -= _movement.DisableSprint;
            _inputService.OnInteractAction -= _interact.Interact;
        }
    }
}
