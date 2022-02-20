using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class levelMediator : EventMediator
{
    [Inject] public levelView view { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(myEvents.INCREASE_SAWMILL, AddSawmill);
    }

    void AddSawmill()
    {
        view.AddSawmillFromPool();
    }
}
