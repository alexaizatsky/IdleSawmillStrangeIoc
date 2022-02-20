using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class increasePriceCommand : Command
{
    public override void Execute()
    {
        Debug.Log("EXECUTE INCREASE PRICE COMMAND");
    }
}
