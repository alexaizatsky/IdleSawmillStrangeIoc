using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDataModel : iSaveData
{
    private int _money;
    private int _priceLevel;
    private int _speedLevel;
    private int _sawmillLevel;
/*
    public saveDataModel(myData _data)
    {
        _money = _data.money;
        _priceLevel = _data.priceLevel;
        _speedLevel = _data.speedLevel;
        _sawmillLevel = _data.sawmillLevel;
    }
  */  
    public int money
    {
        get
        {
            return _money;
        }
    }
    public int priceLevel
    {
        get
        {
            return _priceLevel;
        }
    }
    public int speedLevel
    {
        get
        {
            return _speedLevel;
        }
    }
    public int sawmillLevel
    {
        get
        {
            return _sawmillLevel;
        }
    }
    
    public void IncreaseMoney(int _amount)
    {
        _money += _amount;
    }

    public void ReduceMoney(int _amount)
    {
        _money -= _amount;
    }

    public void IncreasePlayerLevel(gameplaySettingsSO.PlayerLevels _type, int _reduceMoney)
    {
        switch (_type)
        {    
            case gameplaySettingsSO.PlayerLevels.price:
                _priceLevel++;
                break;
            case gameplaySettingsSO.PlayerLevels.speed:
                _speedLevel++;
                break;
            case gameplaySettingsSO.PlayerLevels.sawmill:
                _sawmillLevel++;
                break;
        }
        ReduceMoney(_reduceMoney);
    }

    public void SetSaveValues(myData _myData)
    {
        _money = _myData.money;
        _priceLevel = _myData.priceLevel;
        _speedLevel = _myData.speedLevel;
        _sawmillLevel = _myData.sawmillLevel;
    }
}
