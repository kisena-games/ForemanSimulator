using ForemanSimulator.Runtime.Services.Input;
using System;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventoryPresenter
    {
        private readonly QuickAccessInventory _inventoryModel;
        private readonly QuickAccessInventoryView _inventoryView;

        public QuickAccessInventoryPresenter(QuickAccessInventory model, QuickAccessInventoryView view, IInputService inputService)
        {
            _inventoryModel = model;
            _inventoryView = view;

            Initialize();
        }

        public void Dispose()
        {

        }

        private void Initialize()
        {

        }
    }
}

