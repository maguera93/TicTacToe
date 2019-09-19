using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour contextView) : base(contextView) { }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<ICellModel>().To<CellModel>();
        injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
        injectionBinder.Bind<IServiceModel>().To<ServiceModel>().ToSingleton();

        injectionBinder.Bind<MarkCellSignal>().ToSingleton();
        injectionBinder.Bind<GameOverSignal>().ToSingleton();
        injectionBinder.Bind<MenuSignal>().ToSingleton();
        injectionBinder.Bind<SpawnCellsSignal>().ToSingleton();

        mediationBinder.Bind<GameOverView>().To<GameOverMediator>();
        mediationBinder.Bind<CellView>().To<CellMediator>();
        mediationBinder.Bind<GameView>().To<GameMediator>();
        mediationBinder.Bind<MenuView>().To<MenuMediator>();
        mediationBinder.Bind<LoadView>().To<LoadMediator>();

        commandBinder.Bind<StartSignal>().To<StartGameCommand>().Once();
        commandBinder.Bind<ClickedCellSignal>().To<SelectCellCommand>();
        commandBinder.Bind<EnemyAISignal>().To<EnemyAICommand>();
        commandBinder.Bind<ResetSignal>().To<ResetGameCommand>();
        commandBinder.Bind<WebServiceSignalStart>().To<WebServiceCommand>().Once();
    }

    public override void Launch()
    {
        base.Launch();
        //Start Game Loadoing the AssetBundle
        WebServiceSignalStart webStart = injectionBinder.GetInstance<WebServiceSignalStart>();
        webStart.Dispatch();
    }

}
