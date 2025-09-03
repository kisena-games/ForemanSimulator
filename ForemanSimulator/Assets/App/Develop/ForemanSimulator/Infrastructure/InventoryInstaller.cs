using ForemanSimulator.Runtime.Services.Inventory;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private QuickAccessInventoryView _quickAccessInventoryView;
        [SerializeField] private MainInventoryView _mainInventoryView;
        
        public override void InstallBindings()
        {
            BindPresenters();
            BindViews();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesAndSelfTo<MainInventoryPresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<QuickAccessInventoryPresenter>().AsSingle().NonLazy();
        }

        private void BindViews()
        {
            Container.BindInstance(_quickAccessInventoryView).AsSingle().NonLazy();
            Container.BindInstance(_mainInventoryView).AsSingle().NonLazy();
        }
    }
}