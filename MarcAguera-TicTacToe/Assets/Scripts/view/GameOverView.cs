using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;


class GameOverView : View
{
    public Signal ClickSignal = new Signal { };

    public Button replayButton;
    public Text winText;

    public void Init()
    {
        replayButton.onClick.AddListener(OnClicked);
    }

    public void OnClicked()
    {
        ClickSignal.Dispatch();
    }

    public void SetText(string text)
    {
        winText.text = text;
    }
}
