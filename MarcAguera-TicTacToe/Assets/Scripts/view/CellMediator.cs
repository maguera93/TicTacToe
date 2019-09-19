using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

class CellMediator : Mediator
{
    [Inject]
    public CellView view { get; set; }

    [Inject]
    public ClickedCellSignal clickedCellSignal { get; set; }

    [Inject]
    public MarkCellSignal markCellSignal { get; set; }
    
    [Inject]
    public GameOverSignal gameOverSignal { get; set; }

    [Inject]
    public ResetSignal resetSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.ClickedSignal.AddListener(OnStartButtonSignalDispatched);
        markCellSignal.AddListener(MarkCell);
        gameOverSignal.AddListener(OnGameOver);
        resetSignal.AddListener(OnResetGame);
    }

    private void OnStartButtonSignalDispatched(Vector2Int pos)
    {
        clickedCellSignal.Dispatch(pos);
    }

    private void MarkCell(bool isX, Vector2Int pos)
    {
        if(view.gridPos.x == pos.x && view.gridPos.y == pos.y){
            if (isX) view.SetCell("X");
            else view.SetCell("O");
        }
    }

    private void OnGameOver(string text)
    {
        view.DeactivateButton();
    }

    private void OnResetGame()
    {
        view.Reset();
    }
}