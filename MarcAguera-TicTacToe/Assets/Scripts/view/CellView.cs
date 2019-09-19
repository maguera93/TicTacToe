using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class CellView : View
{
    public Vector2Int gridPos;

    public Signal<Vector2Int> ClickedSignal = new  Signal<Vector2Int> {};

    private Button button;
    private Text text;

    public void Init()
    {
        button = gameObject.GetComponent<Button>(); 
        button.onClick.AddListener(Clicked);
        text = gameObject.GetComponentInChildren<Text>();
    }

    public void Clicked()
    {
        ClickedSignal.Dispatch(gridPos);
    }

    public void SetCell(string XO)
    {
        text.text = XO;
    }

    public void DeactivateButton()
    {
        button.interactable = false;
    }

    public void Reset()
    {
        button.interactable = true;
        text.text = "";
    }
}