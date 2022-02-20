using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class downPanelUIView : EventView
{
    [SerializeField] private ButtonUIDepending[] myButtons;

    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; } 
    
    private gameplaySettingsSO gs;
    private myData dataKeeper;
    private downPanelUIMediator _downPanelUiMediator;
    public void Init(myData data)
    {
        gs = contextView.GetComponent<levelView>().gameplaySettings;
        UpdateData(data);
        _downPanelUiMediator = GetComponent<downPanelUIMediator>();
    }
    
    
  
    public void UpdateData(myData data)
    {
        dataKeeper = data;
        
        if (dataKeeper.priceLevel >= gs.priceProgression.Length - 1)
            myButtons[0].myButton.gameObject.SetActive(false);
        else
            myButtons[0].curPrice = gs.priceProgression[dataKeeper.priceLevel+1].price;

        if (dataKeeper.speedLevel >= gs.speedProgression.Length - 1)
            myButtons[1].myButton.gameObject.SetActive(false);
        else
            myButtons[1].curPrice = gs.speedProgression[dataKeeper.speedLevel+1].price;
       
        if (dataKeeper.sawmillLevel >= gs.sawmillProgression.Length - 1)
            myButtons[2].myButton.gameObject.SetActive(false);
        else
            myButtons[2].curPrice = gs.sawmillProgression[dataKeeper.sawmillLevel+1].price;

        myButtons[0].levelText.text = "Level " + (dataKeeper.priceLevel + 1).ToString();
        myButtons[1].levelText.text = "Level " + (dataKeeper.speedLevel + 1).ToString();
        myButtons[2].levelText.text = "Level " + (dataKeeper.sawmillLevel + 1).ToString();


        for (int i = 0; i < myButtons.Length; i++)
        {
            myButtons[i].priceText.text = myButtons[i].curPrice.ToString() + "$";
            if (dataKeeper.money>=myButtons[i].curPrice)
            {
                myButtons[i].myButton.enabled = true;
                myButtons[i].myButton.GetComponent<Image>().color = Color.white;
            }
            else
            {
                myButtons[i].myButton.enabled = false;
                myButtons[i].myButton.GetComponent<Image>().color = Color.grey;
            }
        }

        
    }
    
    
    
    public void PressPriceButton()
    {
           
  
            int price = gs.priceProgression[dataKeeper.priceLevel + 1].price;
            if (dataKeeper.money >= price)
            {
                _downPanelUiMediator.IncreasePriceLevel(price);
               
            }
      
    }

    public void PressSpeedButton()
    {
        if (dataKeeper.speedLevel<gs.speedProgression.Length-1)
        {
            int price = gs.speedProgression[dataKeeper.speedLevel + 1].price;
            if (dataKeeper.money >= price)
            {
                _downPanelUiMediator.IncreaseSpeedLevel(price);
            }
        }
        else
        {
            myButtons[1].myButton.gameObject.SetActive(false);
        }
    }

    public void PressSawmillButton()
    {
        if (dataKeeper.sawmillLevel<gs.sawmillProgression.Length-1)
        {
            int price = gs.sawmillProgression[dataKeeper.sawmillLevel + 1].price;
            if (dataKeeper.money >= price)
            {
                _downPanelUiMediator.IncreaseSawmillLevel(price);
            }
        }
        else
        {
            myButtons[2].myButton.gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class ButtonUIDepending
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public Button myButton;
    [HideInInspector]public int curPrice;
}