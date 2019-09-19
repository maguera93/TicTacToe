using System;
using System.IO;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class StartGameCommand : Command
{

    [Inject]
    public IGameModel gameModel { get; set; }

    [Inject]
    public IServiceModel serviceModel { get; set; }

    [Inject]
    public SpawnCellsSignal spawnSignal { get; set; }

    public override void Execute()
    {
        gameModel.Reset();
        spawnSignal.Dispatch(serviceModel.cellGO);
    }
}
