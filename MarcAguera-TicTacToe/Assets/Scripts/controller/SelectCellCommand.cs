using System;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class SelectCellCommand : Command
{

    [Inject]
    public IGameModel gameModel { get; set; }

    [Inject]
    public Vector2Int pos { get; set; }


    [Inject]
    public MarkCellSignal markCellSignal{get; set;}
    [Inject]
    public GameOverSignal endgameSignal{get; set;}
    [Inject]
    public EnemyAISignal enemySignal { get; set; }

    public override void Execute()
    {

        if (!gameModel.Cells[pos.x, pos.y].IsClicked)
        {
            markCellSignal.Dispatch(gameModel.IsPlayerTurn, pos);
            gameModel.ClickCell(pos);

            switch (gameModel.gameState())
            {
                case GameState.NotOver:
                    break;
                case GameState.Win:                 
                    endgameSignal.Dispatch("YOU WIN");
                    return;
                case GameState.Lose:
                    endgameSignal.Dispatch("YOU LOSE");
                    return;
                case GameState.Tie:
                    endgameSignal.Dispatch("DRAW");
                    return;
            }

            if (!gameModel.IsPlayerTurn) enemySignal.Dispatch();
        }
    }
}
