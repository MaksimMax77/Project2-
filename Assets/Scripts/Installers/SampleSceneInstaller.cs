using Services;
using Zenject;
using UnityEngine;

namespace Installers
{
    public class SampleSceneInstaller : MonoInstaller
    {
		public GameObject player;

        public override void InstallBindings()
        {
            //Container.Bind<ISaveService>().To<JsonSaveService>().AsSingle().NonLazy();
			Container.Bind<IPause>().To<PauseController>().AsSingle().NonLazy();
		 

		 
			Container.Bind<Ihealth>().FromComponentInChildren(player);
			Container.Bind<IMana>().FromComponentInChildren(player);
		}
    }
}