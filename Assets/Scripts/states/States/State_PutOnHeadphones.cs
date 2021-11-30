using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PutOnHeadphones : Interface_State
{
    public void onEnter()
    {
        Debug.Log("onenter in pickupheadset");
        GameLogicManager.getInstance().spawnHeadphones();
    }

    public void onExecute()
    {
        
    }

    public void onExit()
    {
        GameLogicManager.getInstance().despawnHeadphones();
    }

    public string toString()
    {
        return "State Put On Headphones";
    }
}
