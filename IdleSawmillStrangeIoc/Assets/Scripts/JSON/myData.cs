using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myData
{
    public int money;
    public int priceLevel;
    public int speedLevel;
    public int sawmillLevel;

    public myData(int _money, int _priceLevel, int _speedLevel, int _sawmillLevel)
    {
        money = _money;
        priceLevel = _priceLevel;
        speedLevel = _speedLevel;
        sawmillLevel = _sawmillLevel;
    }
}
