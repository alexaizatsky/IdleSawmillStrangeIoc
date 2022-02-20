using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class forestView : EventView
{

    [Inject] public iForest forestController { get; set; }
    
    public List<treeView> myTrees = new List<treeView>();
    
    public void GenerateNewTrees( GameObject treePrefab)
    {
        for (int h = 0; h < myTrees.Count; h++)
        {
            if (!myTrees[h].isBusy)
                Destroy(myTrees[h].gameObject);
            else
                myTrees[h].lastTree = true;
        }
        myTrees.Clear();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject c = Instantiate(treePrefab);
                c.transform.SetParent(this.transform);
                c.transform.localPosition = new Vector3( j*1.5f-3, 0,i);
                treeView _tree = c.GetComponent<treeView>();
                myTrees.Add(_tree);
             //   _tree.Init(this);
               
            }
        }
        forestController.myTrees = new List<treeView>(myTrees);
        forestController.myTrees = myTrees;
    }
    
}
