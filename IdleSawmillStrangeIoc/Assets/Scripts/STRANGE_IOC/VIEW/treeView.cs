using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class treeView : EventView
{
    [SerializeField] private Transform visualTransform;
    private lumberjackMediator myLumberjack;
    
    [HideInInspector]public bool isBusy;
    [HideInInspector]public bool lastTree;

 
    [Inject] public iForest myForest { get; set; }

    public void StartCuttingMe(lumberjackMediator _lumberjack)
    {
        myLumberjack = _lumberjack;
        myLumberjack.OnCuttingTreeUpdate += CuttingUpdate;
    }
    public void CuttingUpdate(float _progress)
    {
        if (_progress<1)
        {
            visualTransform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), Vector3.zero, _progress);
        }
        else
        {
            DestroyMe();
        }
    }

    void DestroyMe()
    {
        myLumberjack.OnCuttingTreeUpdate -= CuttingUpdate;
        if(!lastTree)
            myForest.DestroyTreeFromList(this);
        Destroy(this.gameObject);
    }
}
