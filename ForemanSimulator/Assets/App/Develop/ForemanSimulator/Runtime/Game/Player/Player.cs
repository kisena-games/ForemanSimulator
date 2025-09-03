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
        private IInputService _inputService;

        private PlayerCamera _cameraService;
        private PlayerMovement _movement;
        private PlayerStamina _stamina;
        private PlayerInteract _interact;
        private QuickAccessInventoryPresenter _quickAccessInventoryPresenter;
        private MainInventoryPresenter _mainInventoryPresenter;

        [Inject]
        private void Construct(IInputService inputService,
            MainInventoryPresenter mainInventoryPresenter,
            QuickAccessInventoryPresenter quickAccessInventoryPresenter,
            PlayerCamera playerCamera,
            PlayerMovement playerMovement,
            PlayerStamina playerStamina,
            PlayerInteract playerInteract)
        {
            _inputService = inputService;
            _mainInventoryPresenter = mainInventoryPresenter;
            _quickAccessInventoryPresenter = quickAccessInventoryPresenter;
            _cameraService = playerCamera;
            _movement = playerMovement;
            _stamina = playerStamina;
            _interact = playerInteract;
        }

        private void Awake()
        {
            InitializePlayerMovement();
            InitializePlayerStamina();
            InitializeInteract();
            InitializeInventories();
        }

        private void InitializePlayerMovement()
        {
            _inputService.OnJumpAction += _movement.Jump;
        }

        private void InitializePlayerStamina()
        {
            _stamina.OnEmptyStamina += _movement.DisableSprint;
        }

        private void InitializeInteract()
        {
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
