using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using ForemanSimulator.Runtime.Services.Inventory;
using ForemanSimulator.Runtime.Services.Player;
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

        private IInputService _inputService;

        private PlayerCamera _cameraService;
        private PlayerMovement _movement;
        private PlayerStamina _stamina;
        private PlayerInteract _interact;
        private QuickAccessInventoryPresenter _quickAccessInventoryPresenter;
        private MainInventoryPresenter _mainInventoryPresenter;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            Initialize();
        }

        public void Initialize()
        {
            InitializePlayerCamera();
            InitializePlayerMovement();
            InitializePlayerStamina();
            InitializeInteract();
            InitializeInventories();
        }

        private void InitializePlayerCamera()
        {
            _cameraService = new PlayerCamera(_camera);
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
            QuickAccessInventory _quickAccessInventory = new QuickAccessInventory(9);
            MainInventory _mainInventory = new MainInventory(3, 5);

            _quickAccessInventoryPresenter = new QuickAccessInventoryPresenter(_quickAccessInventory, _quickAccessInventoryView, _inputService);
            _mainInventoryPresenter = new MainInventoryPresenter(_mainInventory, _mainInventoryView, _inputService);
            _mainInventoryPresenter.OnToggleAction += _cameraService.LockRotation;
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
            _mainInventoryPresenter.OnToggleAction -= _cameraService.LockRotation;

            _quickAccessInventoryPresenter.Dispose();
            _mainInventoryPresenter.Dispose();
        }
    }
}
