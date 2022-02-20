using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.mediation.impl;
using UnityEngine;

public class forestController : iForest
{
    private List<treeView> _myTrees;
    
 //   [Inject]
  //  public IEventDispatcher dispatcher{get;set;}
  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
  public IEventDispatcher dispatcher{ get; set;}
    
    public List<treeView> myTrees
    {
        get
        {
            return _myTrees;
        }


        set => _myTrees = value;
    }


    public void DestroyTreeFromList(treeView _tree)
    {
        if (_myTrees.Contains(_tree))
        {
            for (int i = 0; i < _myTrees.Count; i++)
            {
                if (_myTrees[i] == _tree)
                {
                    _myTrees.RemoveAt(i);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("NU SUCH TREE IN LIST");
        }
    }

    public treeView GetClosestTree(Vector3 _pos)
    {
        if (_myTrees.Count < 3)
        {
            Debug.Log("NEED NEW TREES");
            dispatcher.Dispatch(myEvents.REGENERATE_FOREST);
        }
        float dist = 1000;
        int arrNumb = 0;
        for (int i = 0; i < _myTrees.Count; i++)
        {
            if ((_myTrees[i].transform.position - _pos).magnitude < dist && !_myTrees[i].isBusy)
            {
                dist = (_myTrees[i].transform.position - _pos).magnitude;
                arrNumb = i;
            }
        }

       _myTrees[arrNumb].isBusy = true;
        return _myTrees[arrNumb];
    }
}
