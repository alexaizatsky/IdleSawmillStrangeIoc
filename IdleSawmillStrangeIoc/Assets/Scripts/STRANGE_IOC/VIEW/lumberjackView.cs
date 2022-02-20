using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class lumberjackView : EventView
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image fillImage;
    public sawmillView mySawmill;
    private MethodCallback callback;

    public void Init(sawmillView _sawmillView)
    {
        mySawmill = _sawmillView;
    }
    public void MoveToForest(Vector3 _point, float _time, MethodCallback _callback)
    {
        callback = _callback;
        this.transform.DOMove(_point, _time).OnComplete(FinMoveForest);
    }

    void FinMoveForest()
    {
        callback.Invoke();
    }
    public void MoveToSawmil(Vector3 _point, float _time, MethodCallback _callback)
    {
        callback = _callback;
        this.transform.DOMove(_point, _time).OnComplete(FinMoveSawmill);
    }

    void FinMoveSawmill()
    {
        callback.Invoke();
    }
    
    
    
    public void ActivateProgressUI(bool _active)
    {
        fillImage.fillAmount = 0;
        canvas.SetActive(_active);
    }

    public void ProgressUIUpdate(float _progress)
    {
        fillImage.fillAmount = _progress;
    }
}
