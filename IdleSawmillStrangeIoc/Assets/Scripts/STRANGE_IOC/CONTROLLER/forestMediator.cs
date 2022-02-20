using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class forestMediator : EventMediator
{
    [Inject] public forestView view { get; set; }
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; } 

  //  public List<treeView> myTrees = new List<treeView>();
    public override void OnRegister()
    {
        base.OnRegister();
        GenerateNewTrees();
        dispatcher.AddListener(myEvents.REGENERATE_FOREST, GenerateNewTrees);
    }

    public void GenerateNewTrees()
    {
        view.GenerateNewTrees( contextView.GetComponent<levelView>().gameplaySettings.treePrefab);
    }

    
}
