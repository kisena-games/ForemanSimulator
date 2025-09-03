using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Game.Player;
using ForemanSimulator.Runtime.Services.Player;
using Unity.Cinemachine;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private CharacterController _characterController;
        [Header("Configs")]
        [SerializeField] private PlayerMovementConfig playerMovementConfig;
        [SerializeField] private PlayerStaminaConfig playerStaminaConfig;
        //TODO: Вынести layerMask в PlayerInteractConfig
        [SerializeField] private LayerMask _interactMask;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle().NonLazy();
            Container.BindInstance(_characterController).AsSingle().NonLazy();
            Container.BindInstance(_interactMask).AsSingle().NonLazy();
            BindServices();
            BindConfigs();
        }

        private void BindConfigs()
        {
            Container.BindInstance(playerMovementConfig).AsSingle().NonLazy();
            Container.BindInstance(playerStaminaConfig).AsSingle().NonLazy();
        }
        
        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<PlayerCamera>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerStamina>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerInteract>().AsSingle().NonLazy();
        }
    }
}