using ForemanSimulator.Runtime.Services.Input;
using System;
using Infrastructure.EventBus;
using Infrastructure.EventBus.Signals;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class MainInventoryPresenter : IInitializable, IDisposable
    {
        public event Action<bool> OnToggleAction;

        private MainInventory _inventoryModel;
        private MainInventoryView _inventoryView;

        private EventBus _eventBus;
        private IInputService _inputService;
        private bool _isOpen = false;

        [Inject]
        private void Construct(MainInventoryView view, EventBus eventBus, IInputService inputService)
        {
            _inventoryModel = new MainInventory(3, 5);
            _inventoryView = view;
            _eventBus = eventBus;
            _inputService = inputService;
        }
 
        public void Initialize()
        {
            _inputService.OnMainInventoryAction += ToggleInventory;
            OnToggleAction += _inputService.LockMouse;
            _inventoryView.SetActive(false);
        }

        private void ToggleInventory()
        {
            _isOpen = !_isOpen;

            _inventoryView.SetActive(_isOpen);
            _eventBus.Invoke(new InventoryActionSignal(_isOpen));
            OnToggleAction?.Invoke(_isOpen);
        }
        
        public void Dispose()
        {
            _inputService.OnMainInventoryAction -= ToggleInventory;
            OnToggleAction -= _inputService.LockMouse;
        }
    }
}
