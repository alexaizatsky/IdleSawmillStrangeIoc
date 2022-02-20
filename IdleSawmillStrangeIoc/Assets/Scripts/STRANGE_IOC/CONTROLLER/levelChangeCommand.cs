using System.Collections;
using System.Collections.Generic;
using System.IO;
using strange.extensions.command.impl;
using UnityEngine;

public class levelChangeCommand : EventCommand
{
    private myData  writeMyData;
    private string fileName = "myData.json";
    private string filePath;
    private string dataToJson;
    
    [Inject] public iSaveData dataKeeper { get; set; }
    public override void Execute()
    {
        
        WriteToJson();
        
    }
    
    public void WriteToJson()
    {
      
        
        if (Application.isEditor)
            filePath = Path.Combine(Application.dataPath, fileName);
        else
            filePath = Path.Combine(Application.persistentDataPath + "/", fileName);
   
        
        
        
        writeMyData = new myData(dataKeeper.money, dataKeeper.priceLevel, dataKeeper.speedLevel,
            dataKeeper.sawmillLevel);
        dataToJson = JsonUtility.ToJson(writeMyData);
        File.WriteAllText(filePath, dataToJson);
    }
}
