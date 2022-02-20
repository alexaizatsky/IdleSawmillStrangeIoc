using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class appStart : ContextView
{
    private void Awake()
    {
        context = new myContext(this);
    }
}
