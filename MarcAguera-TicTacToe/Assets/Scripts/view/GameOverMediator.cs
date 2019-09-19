using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;


class GameOverMediator : Mediator
{
    [Inject]
    public GameOverView view { get; set; }

    [Inject]
    public ResetSignal resetSignal { get; set; }

    [Inject]
    public GameOverSignal gameOverSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.ClickSignal.AddListener(OnProced);
        gameOverSignal.AddListener(Show);

        Hide();
    }

    private void Show(string text)
    {
        gameObject.SetActive(true);
        view.SetText(text);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnProced()
    {
        resetSignal.Dispatch();
        Hide();
    }
}
