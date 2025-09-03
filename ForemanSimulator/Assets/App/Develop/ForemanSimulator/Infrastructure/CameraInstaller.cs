using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Container.BindInstance(_camera).AsSingle().NonLazy();
            Container.BindInstance(_cinemachineCamera).AsSingle().NonLazy();
        }
    }
}