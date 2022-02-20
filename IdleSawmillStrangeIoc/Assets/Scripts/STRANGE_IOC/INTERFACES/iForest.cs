using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iForest
{
    List<treeView> myTrees { get; set; }
    
    void DestroyTreeFromList(treeView _tree);

    treeView GetClosestTree( Vector3 _pos);
}
