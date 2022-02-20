using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class uiView : EventView
{
    [SerializeField] private upPanelUIView _upPanelUi;
    [SerializeField] private downPanelUIView _downPanelUi;

    public void Init()
    {
        _upPanelUi.gameObject.SetActive(true);
        _downPanelUi.gameObject.SetActive(true);
       
    }
}
