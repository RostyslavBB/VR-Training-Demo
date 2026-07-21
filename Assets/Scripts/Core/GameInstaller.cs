using Gameplay.Training;
using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private TrainingManager _trainingManager;

    public override void InstallBindings()
    {
        Container.Bind<TrainingManager>()
            .FromInstance(_trainingManager)
            .AsSingle();
    }
}