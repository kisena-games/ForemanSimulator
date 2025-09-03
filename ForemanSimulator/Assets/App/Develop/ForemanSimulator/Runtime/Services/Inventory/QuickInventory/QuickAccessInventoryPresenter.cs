using ForemanSimulator.Runtime.Services.Input;
using System;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventoryPresenter : IInitializable, IDisposable
    {
        private QuickAccessInventory _inventoryModel;
        private QuickAccessInventoryView _inventoryView;
        
        [Inject]
        private void Construct(QuickAccessInventoryView view)
        {
            _inventoryModel = new QuickAccessInventory(9);
            _inventoryView = view;
        }

        public void Initialize()
        {
            
        }
        
        public void Dispose()
        {

        }
    }
}

