using ForemanSimulator.Runtime.Services.Input;
using IceControl.Runtime.Services.Input;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<NewInputService>().AsSingle().NonLazy();
        }
    }
}
