using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class LoadMediator : Mediator {

    [Inject]
    public LoadView view { get; set; }

    [Inject]
    public MenuSignal menuSignal {get; set;}

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        menuSignal.AddListener(Hide);
    }

    void Hide()
    {
        view.Hide();
    }

}
