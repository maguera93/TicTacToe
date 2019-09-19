using System;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class ResetGameCommand : Command
{

    [Inject]
    public IGameModel gameModel { get; set; }

    public override void Execute()
    {
        gameModel.Reset();  
    }
}
