using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using ForemanSimulator.Runtime.Services.Inventory;
using ForemanSimulator.Runtime.Services.Player;
using Infrastructure.EventBus;
using Infrastructure.EventBus.Signals;
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

        private IInputService _inputService;

        private PlayerCamera _cameraService;
        private PlayerMovement _movement;
        private PlayerStamina _stamina;
        private PlayerInteract _interact;
        private QuickAccessInventoryPresenter _quickAccessInventoryPresenter;
        private MainInventoryPresenter _mainInventoryPresenter;
        private EventBus _eventBus;
        
        [Inject]
        public void Construct(IInputService inputService,
            MainInventoryPresenter mainInventoryPresenter,
            QuickAccessInventoryPresenter quickAccessInventoryPresenter,
            EventBus eventBus)
        {
            _inputService = inputService;
            _mainInventoryPresenter = mainInventoryPresenter;
            _quickAccessInventoryPresenter = quickAccessInventoryPresenter;
            _eventBus = eventBus;
        }

        private void Awake()
        {
            InitializePlayerCamera();
            InitializePlayerMovement();
            InitializePlayerStamina();
            InitializeInteract();
            InitializeInventories();
            _eventBus.Subscribe<InventoryActionSignal>(Test, 0);
        }

        private void Test(InventoryActionSignal signal)
        {
            Debug.Log(signal.IsOpen);
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
