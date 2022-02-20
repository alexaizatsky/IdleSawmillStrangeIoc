using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class levelView : EventView
{
    public gameplaySettingsSO gameplaySettings;

    
    private levelPrefabView _levelPrefab;
    private forestView _forest;
    private List<sawmillView> mySawmills = new List<sawmillView>();

    [Inject] public iSaveData dataKeeper { get; set; }

    public void Init()
    {
        _levelPrefab = GenerateLevel();
        _forest = GenerateForest();
         GenerateStartSawmills();
    }
    
    levelPrefabView GenerateLevel()
    {
        GameObject c = Instantiate(gameplaySettings.levelPrefab);
        c.transform.position = Vector3.zero;
        c.transform.eulerAngles = Vector3.zero;
        c.transform.localScale = new Vector3(1,1,1);
        return c.GetComponent<levelPrefabView>();

    }

    forestView GenerateForest()
    {
        GameObject c = Instantiate(gameplaySettings.forestPrefab);
        c.transform.position = Vector3.zero;
        c.transform.eulerAngles = Vector3.zero;
        c.transform.localScale = new Vector3(1,1,1);
        return c.GetComponent<forestView>();
    }
    
    
    void GenerateStartSawmills()
    {
        for (int i = 0; i < _levelPrefab.sawmillsPoints.Length; i++)
        {
            GameObject c = Instantiate(gameplaySettings.sawmillPrefab);
            c.transform.position = _levelPrefab.sawmillsPoints[i].position;
            c.transform.eulerAngles = _levelPrefab.sawmillsPoints[i].eulerAngles;
            mySawmills.Add(c.GetComponent<sawmillView>());
            if (dataKeeper.sawmillLevel<i)
            {
                c.SetActive(false);
            }
        }
    }

    public void AddSawmillFromPool()
    {
        if (dataKeeper.sawmillLevel<mySawmills.Count)
        {
            mySawmills[dataKeeper.sawmillLevel].gameObject.SetActive(true);
        }
    }

   
}
