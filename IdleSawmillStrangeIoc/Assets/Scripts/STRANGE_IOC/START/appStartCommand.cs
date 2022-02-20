using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class appStartCommand : Command
{
    
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; } 
    public override void Execute()
    {
        contextView.GetComponent<levelView>().Init();
        contextView.GetComponent<uiView>().Init();
        
    }
}
