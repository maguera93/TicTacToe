using System;
using strange.extensions.command.impl;
using UnityEngine;

public class EnemyAICommand : Command
{

    [Inject]
    public IGameModel gridModel { get; set; }

    [Inject]
    public ClickedCellSignal clickedCellSignal { get; set; }

    private int[,] scores;


    public override void Execute()
    {
        Vector2Int pos = new Vector2Int(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(0, 3));

        while(gridModel.Cells[(int)pos.x, (int)pos.y].IsClicked)
        {
            pos = new Vector2Int(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(0, 3));
        }

        clickedCellSignal.Dispatch(pos);
    }
    /*
    private float EvaluatePosition(int x, int y, int p)
    {
        if (gridModel.Cells[y, x] == 0)
            return 1f;
        else if (board[y, x] == p)
            return 2f;
        return -1;
    }

    private float EvaluateNeighbours(int x, int y, int p)
    {
        float eval = 0f;
        int i, j;
        for (i = y - 1; i < y + 2; y++)
        {
            if (i < 0 || i >= 3)
                continue;
            for (j = x - 1; j < x + 2; j++)
            {
                if (j < 0 || j >= 3)
                    continue;
                if (i == j)
                    continue;
                eval += EvaluatePosition(j, i, p);
            }
        }
        return eval;
    }

    public Vector2 BestMove()
    {
        int MAX = -100000;
        int best = -1;

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                
            }
            
        }
        
        
        return Vector2.zero;
    }*/
}
