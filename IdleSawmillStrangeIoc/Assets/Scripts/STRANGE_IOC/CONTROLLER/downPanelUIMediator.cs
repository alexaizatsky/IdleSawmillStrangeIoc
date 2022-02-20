using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class downPanelUIMediator : EventMediator
{
    [Inject] public downPanelUIView view { get; set; }
    [Inject] public iSaveData dataKeeper { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init(new myData(dataKeeper.money, dataKeeper.priceLevel, dataKeeper.speedLevel,dataKeeper.sawmillLevel));
        dispatcher.AddListener(myEvents.MONEY_UPDATE, DownMoneyUpdate);
        dispatcher.AddListener(myEvents.LEVEL_UPDATE, LevelUpdate);
    }

    void DownMoneyUpdate()
    {
        view.UpdateData(new myData(dataKeeper.money, dataKeeper.priceLevel, dataKeeper.speedLevel,dataKeeper.sawmillLevel));
    }

    void LevelUpdate()
    {
        view.UpdateData(new myData(dataKeeper.money, dataKeeper.priceLevel, dataKeeper.speedLevel,dataKeeper.sawmillLevel));

    }

    public void IncreasePriceLevel(int _price)
    {
        dataKeeper.IncreasePlayerLevel(gameplaySettingsSO.PlayerLevels.price, _price);
        dispatcher.Dispatch(myEvents.INCREASE_PRICE);
        dispatcher.Dispatch(myEvents.LEVEL_UPDATE);
        dispatcher.Dispatch(myEvents.MONEY_UPDATE);
    }
    public void IncreaseSpeedLevel(int _price)
    {
        dataKeeper.IncreasePlayerLevel(gameplaySettingsSO.PlayerLevels.speed, _price);
        dispatcher.Dispatch(myEvents.INCREASE_SPEED);
        dispatcher.Dispatch(myEvents.LEVEL_UPDATE);
        dispatcher.Dispatch(myEvents.MONEY_UPDATE);
    }
    public void IncreaseSawmillLevel(int _price)
    {
        dataKeeper.IncreasePlayerLevel(gameplaySettingsSO.PlayerLevels.sawmill, _price);
        dispatcher.Dispatch(myEvents.INCREASE_SAWMILL);
        dispatcher.Dispatch(myEvents.LEVEL_UPDATE);
        dispatcher.Dispatch(myEvents.MONEY_UPDATE);
    }
    
}
