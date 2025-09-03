using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneHandler>().AsSingle();
            Container.Bind<BootstrapRunner>().AsSingle().NonLazy();
        }
    }
}

