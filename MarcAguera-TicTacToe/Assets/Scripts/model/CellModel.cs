using System;
using System.Collections.Generic;


class CellModel : ICellModel
{
    private bool _clicked;
    private int _player;

    public CellModel()
    {
        Reset();
    }

    public bool IsClicked
    {
        get
        {
            return _clicked;
        }
    }

    public int player
    {
        get
        {
            return _player;
        }
    }

    public void Reset()
    {
        _clicked = false;
        _player = 0;
    }

    public void Click(int player)
    {
        _clicked = true;
        _player = player;
    }
}
