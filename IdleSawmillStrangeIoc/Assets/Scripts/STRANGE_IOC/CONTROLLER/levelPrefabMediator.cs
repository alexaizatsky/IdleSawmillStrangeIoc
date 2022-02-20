using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class levelPrefabMediator : EventMediator
{
    [Inject] public levelPrefabView view { get; set; }

    public Transform[] GetSawmillPoints()
    {
       return view.sawmillsPoints;
    }
}
