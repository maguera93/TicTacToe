using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class GameMediator : Mediator
{
    [Inject]
    public GameView view { get; set; }

    [Inject]
    public StartSignal startSignal { get; set; }

    [Inject]
    public MenuSignal menuSignal { get; set; }

    [Inject]
    public SpawnCellsSignal spawnSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        menuSignal.AddListener(Hide);
        startSignal.AddListener(Show);
        spawnSignal.AddListener(SpawnCells);
        Hide();
    }

    public override void OnRemove()
    {
        base.OnRemove();
        menuSignal.RemoveListener(Hide);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    void SpawnCells(GameObject cellsGO)
    {
        view.SpawnCells(cellsGO);
    }
}
