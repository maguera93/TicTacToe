using UnityEngine;
using System;
using System.Collections.Generic;

class GameModel : IGameModel
{
    private ICellModel[,] _cells;
    private int _playerTurn = 1;

    private int _movementsCounter;

    public GameModel()
    {
        _cells = new ICellModel[3,3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _cells[i, j] = new CellModel();
            }
        }
    }

    public ICellModel[,] Cells
    {
        get
        {
            return _cells;
        }
    }

    public bool IsPlayerTurn
    {
        get
        {
            if(_playerTurn == 1)
            {
                return true;
            }
            else return false;
        }
    }

    public void ClickCell(Vector2Int pos)
    {
        _cells[pos.x, pos.y].Click(_playerTurn);
        _playerTurn *= -1;
        _movementsCounter++;
    }

    public void Reset()
    {
        _playerTurn = 1;
        _movementsCounter = 0;
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _cells[i, j].Reset();
            }
        }
    }

    public GameState gameState()
    {

        if (CheckWins(1))
            return GameState.Win;

        if (CheckWins(-1))
            return GameState.Lose;

        if (_movementsCounter >= 9)
            return GameState.Tie;

        return GameState.NotOver;
    }

    private bool CheckWins(int player)
    {
        //diagonal win
        if (CheckDiagonalWin(player))
            return true;

        //diagonal win
        if (CheckDiagonal2Win(player))
            return true;

        for (int i = 0; i < 3; ++i)
        {
            //row win
            if (CheckRowWin(player, i))
                return true;

            //column win
            if (CheckColWin(player, i))
                return true;
        }
        return false;
    }

#region Checkers
    private bool CheckRowWin(int player, int i)
    {
        
        for (int j = 0; j < 3; j++)
        {
            if (_cells[i, j].player != player) return false;

        }
        return true;
    }

    private bool CheckColWin(int player, int i)
    {
        for (int j = 0; j < 3; j++)
        {
            if (_cells[j, i].player != player) return false;
        }
        return true;
    }

    private bool CheckDiagonalWin(int player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_cells[i, i].player != player) return false;
        }
        return true;
    }

    private bool CheckDiagonal2Win(int player)
    {
        int j = 0;
        for (int i = 2; i >= 0; i--)
        {
            if (_cells[i, j].player != player) return false;
            j++;
        }
        return true;
    }
#endregion
}
