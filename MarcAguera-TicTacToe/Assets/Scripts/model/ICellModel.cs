using System;
using System.Collections.Generic;

public interface ICellModel
{
    bool IsClicked { get; }
    int player{ get; }
    void Reset();
    void Click(int player);
}
