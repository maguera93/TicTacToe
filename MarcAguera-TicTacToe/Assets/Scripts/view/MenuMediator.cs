using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MenuMediator : Mediator {

    [Inject]
    public MenuView view { get; set; }

    [Inject]
    public MenuSignal menuSignal { get; set; }

    [Inject]
    public StartSignal startSignal { get; set; }

    [Inject]
    public WebServiceSignalStart webService { get; set; }

    public override void OnRegister()
    {
        view.PlaySignal.AddListener(OnProceed);
        menuSignal.AddListener(Show);
        webService.AddListener(Hide);
        view.Init();
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        view.Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnProceed()
    {
        Hide();
        startSignal.Dispatch();
    }
}
