using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MethodCallback();
public enum myEvents 
{
    MONEY_UPDATE,
    LEVEL_UPDATE,
    INCREASE_PRICE,
    INCREASE_SPEED,
    INCREASE_SAWMILL,
    REGENERATE_FOREST,
}
