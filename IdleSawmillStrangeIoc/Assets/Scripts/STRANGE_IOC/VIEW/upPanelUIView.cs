using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

public class upPanelUIView : EventView
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private int localMoney;
    private int worldMoney;
    private Coroutine smoothCor;
    
  
    
    public void Init(int _mon)
    {
        worldMoney = _mon;
        localMoney = worldMoney;
      
        moneyText.text = worldMoney.ToString() + "$";
   
    }

    public void MoneyUpdate(int mon)
    {
        worldMoney = mon;
        if (localMoney!=worldMoney)
        {
            if(smoothCor!=null)
                StopCoroutine(smoothCor);
            smoothCor = StartCoroutine(SmoothChangeMoney(worldMoney, 0.3f));
        }
    }
    
    IEnumerator SmoothChangeMoney(int _amount, float _time)
    {
        float timer = 0;
        int startMoney = localMoney;
        while (timer<_time)
        {
            timer += Time.deltaTime;
            float prog = Mathf.InverseLerp(0, _time, timer);
            localMoney = Mathf.RoundToInt(Mathf.Lerp(startMoney, _amount, prog));
            moneyText.text = localMoney.ToString() + "$";
            yield return null;
        }
        localMoney = _amount;
        moneyText.text = localMoney.ToString() + "$";
    }
}
