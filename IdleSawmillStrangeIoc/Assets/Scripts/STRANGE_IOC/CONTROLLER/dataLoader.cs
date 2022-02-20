using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;
using System.IO;

public class dataLoader : EventCommand
{
  

    [Inject] 
    public iSaveData dataKeeper { get; set; }
    
    private string dataToJson;
    private string dataFromJson;
    private string defaultData;
    private myData readMyData, writeMyData;
    private string fileName = "myData.json";
    private string filePath;
    
    
    public override void Execute()
    {
        writeMyData = new myData(30,0,0,0);
        defaultData = JsonUtility.ToJson(writeMyData);
        
        if (Application.isEditor)
            filePath = Path.Combine(Application.dataPath, fileName);
        else
            filePath = Path.Combine(Application.persistentDataPath + "/", fileName);
   
        if (File.Exists(filePath))
        {
            ReadFromJson();
        }
        else
        {
            File.WriteAllText(filePath, defaultData);
            ReadFromJson();
        }
        
        dataKeeper.SetSaveValues(readMyData);
     
    }
    
    void ReadFromJson()
    {
        dataFromJson = File.ReadAllText(filePath);
        readMyData = JsonUtility.FromJson<myData>(dataFromJson);
    }
    
}
