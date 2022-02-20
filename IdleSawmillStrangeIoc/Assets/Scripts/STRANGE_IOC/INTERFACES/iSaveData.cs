using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSaveData 
{
    int money { get; }
    int priceLevel { get; }
    int speedLevel { get; } 
    int sawmillLevel { get; }

    void IncreaseMoney(int _amount);

    void ReduceMoney(int _amount);

    void IncreasePlayerLevel(gameplaySettingsSO.PlayerLevels _type, int _reduceMoney);

    void SetSaveValues(myData _myData);
}
