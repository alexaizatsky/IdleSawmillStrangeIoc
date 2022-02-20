using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class upPanelUIMediator : EventMediator
{
    [Inject] public upPanelUIView view { get; set; }
    [Inject] public iSaveData dataKeeper { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init(dataKeeper.money);
        dispatcher.AddListener(myEvents.MONEY_UPDATE, MoneyUpdate);
    }

    void MoneyUpdate()
    {
        view.MoneyUpdate(dataKeeper.money);
    }
}
