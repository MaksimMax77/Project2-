using Services;
using Zenject;

namespace Installers
{
    public class SampleSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveService>().To<JsonSaveService>().AsSingle().NonLazy();
			Container.Bind<IPlayerXP>().To<PlayerXP>().AsSingle();
		}
    }
}