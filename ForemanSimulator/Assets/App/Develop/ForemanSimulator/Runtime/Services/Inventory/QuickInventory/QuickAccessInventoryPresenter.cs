using System;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventoryPresenter
    {
        private readonly QuickAccessInventory _inventoryModel;
        private readonly QuickAccessInventoryView _inventoryView;

        public QuickAccessInventoryPresenter(QuickAccessInventory model, QuickAccessInventoryView view)
        {
            _inventoryModel = model;
            _inventoryView = view;

            Initialize();
        }

        private void Initialize()
        {

        }
    }
}

