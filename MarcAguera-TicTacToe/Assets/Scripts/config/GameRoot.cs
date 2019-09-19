using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;


public class GameRoot : ContextView
{

    void Awake()
    {
        context = new GameContext(this);
    }

}