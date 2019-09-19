using System;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NotOver, Win, Lose, Tie };

public interface IGameModel
{
    ICellModel[,] Cells { get; }
    void Reset();
    void ClickCell(Vector2Int pos);
    bool IsPlayerTurn { get; }
    GameState gameState();
}
