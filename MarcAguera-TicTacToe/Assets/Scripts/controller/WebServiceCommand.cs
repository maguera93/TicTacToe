using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class WebServiceCommand : Command {

    [Inject]
    public IServiceModel serviceModel { get; set; }

    public override void Execute()
    {

        serviceModel.Load();
    }
}
