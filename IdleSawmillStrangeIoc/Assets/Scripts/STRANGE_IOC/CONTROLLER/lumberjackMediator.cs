using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public delegate void CuttingTreeViewUpdate(float _progress);
public class lumberjackMediator : EventMediator
{
    [Inject] public lumberjackView view { get; set; }
    
    [Inject] public iSaveData dataKeeper { get; set; }
    
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; }
    
    [Inject] public iForest curForest { get; set; }

 
    public enum State
    {
        wait,
        moveToForest,
        chopTree,
        moveToSaw,
    }

    public State myState;
    
    private float moveSpeed;
    private float chopSpeed;
    private int woodPrice;
    
    private gameplaySettingsSO gs;

    
    private treeView nextTree;

    public event CuttingTreeViewUpdate OnCuttingTreeUpdate;
    public override void OnRegister()
    {
        base.OnRegister();
        gs = contextView.GetComponent<levelView>().gameplaySettings;
        dispatcher.AddListener(myEvents.INCREASE_PRICE, ChangeData);
        dispatcher.AddListener(myEvents.INCREASE_SPEED, ChangeData);
        ChangeData();
        SetState(State.moveToForest);
    }
    
    
    public void ChangeData()
    {
        if (dataKeeper.speedLevel < gs.speedProgression.Length)
        {
            moveSpeed = gs.lumberjackMoveSpeed*gs.speedProgression[dataKeeper.speedLevel].multiplier;
            chopSpeed = gs.lumberjackChopSpeed*gs.speedProgression[dataKeeper.speedLevel].multiplier;
        }
        else
        {
            Debug.LogWarning("INCORRECT SAVE DATA");
            moveSpeed = gs.lumberjackMoveSpeed;
            chopSpeed = gs.lumberjackChopSpeed;
        }

        if (dataKeeper.priceLevel<gs.priceProgression.Length)
        {
            woodPrice = Mathf.RoundToInt( gs.woodPrice*gs.priceProgression[dataKeeper.priceLevel].multiplier);
        }
        else
        {
            Debug.LogWarning("INCORRECT SAVE DATA");
            woodPrice = gs.woodPrice;
        }
    }

    void SetState(State s)
    {
        myState = s;
        if (s == State.moveToForest)
        {
            nextTree = curForest.GetClosestTree(view.transform.position);
            Vector3 dir = (this.transform.position - nextTree.transform.position).normalized;
            Vector3 nextPos = nextTree.transform.position +dir*0.8f;
            nextPos.y = 0;
            float dist = (nextTree.transform.position - this.transform.position).magnitude;
            float t = dist / moveSpeed;
            
           view.MoveToForest(nextPos, t, FinMoveToForest);
        }
        else if(s == State.chopTree)
        {
            nextTree.StartCuttingMe(this);
            StartCoroutine(ChopTree(10/chopSpeed));
        }
        else if(s == State.moveToSaw)
        {
            Vector3 newPos = view.mySawmill.transform.position + new Vector3(0, 0, 1);
            float dist = (newPos- this.transform.position).magnitude;
            float t = dist / moveSpeed;
            view.MoveToSawmil(newPos, t, FinSawMove);
        }
    }

    void FinMoveToForest()
    {
        SetState(State.chopTree);
    }

    void FinChopTree()
    {
        SetState(State.moveToSaw);
    }
    void FinSawMove()
    {
        view.mySawmill.GetComponent<sawmillMediator>().GetIncome(woodPrice);
        SetState(State.moveToForest);
    }
    
    
    IEnumerator ChopTree(float _time)
    {
        float timer = 0;
        view.ActivateProgressUI(true);
        while (timer<=_time)
        {
            timer += Time.deltaTime;
            float prog = Mathf.InverseLerp(0, _time, timer);
            view.ProgressUIUpdate(prog);
            if (OnCuttingTreeUpdate != null)
                OnCuttingTreeUpdate(prog);
            yield return null;
        }
        if (OnCuttingTreeUpdate != null)
            OnCuttingTreeUpdate(1);
        view.ActivateProgressUI(false);
        FinChopTree();
    }
    
}
