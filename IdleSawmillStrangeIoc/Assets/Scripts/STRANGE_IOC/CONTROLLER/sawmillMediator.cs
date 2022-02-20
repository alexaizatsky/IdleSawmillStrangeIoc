using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class sawmillMediator : EventMediator
{
    [Inject] public sawmillView view { get; set;}
    
    [Inject] public iSaveData dataKeeper { get; set; }
    
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; } 

    private lumberjackView myLumberjack;
    public override void OnRegister()
    {
        base.OnRegister();
        if (myLumberjack==null)
        {
            myLumberjack =
                view.GenerateLumberjack(contextView.GetComponent<levelView>().gameplaySettings.lumberjackPrefab);

        }
    }

   
    public void GetIncome(int _money)
    {
        dataKeeper.IncreaseMoney(_money);
        dispatcher.Dispatch(myEvents.MONEY_UPDATE);
        view.OnScale();
    }
}
