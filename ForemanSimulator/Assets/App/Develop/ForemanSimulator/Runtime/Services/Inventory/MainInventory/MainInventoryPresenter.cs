using ForemanSimulator.Runtime.Services.Input;
using System;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class MainInventoryPresenter
    {
        public event Action<bool> OnToggleAction;

        private readonly MainInventory _inventoryModel;
        private readonly MainInventoryView _inventoryView;

        private IInputService _inputService;
        private bool _isOpen = false;

        public MainInventoryPresenter(MainInventory model, MainInventoryView view, IInputService inputService)
        {
            _inventoryModel = model;
            _inventoryView = view;
            _inputService = inputService;

            Initialize();
        }

        public void Dispose()
        {
            _inputService.OnMainInventoryAction -= ToggleInventory;
            OnToggleAction -= _inputService.Lock;
        }

        private void Initialize()
        {
            _inputService.OnMainInventoryAction += ToggleInventory;
            OnToggleAction += _inputService.Lock;
            _inventoryView.SetActive(false);
        }

        private void ToggleInventory()
        {
            _isOpen = !_isOpen;

            _inventoryView.SetActive(_isOpen);
            OnToggleAction?.Invoke(_isOpen);
        }
    }
}
