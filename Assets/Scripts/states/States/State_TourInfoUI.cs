using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_TourInfoUI : Interface_State
{


    public void onEnter()
    {
        Debug.Log("Entered tour info ui state");
        GameLogicManager.getInstance().rayCastingMode("UI");
        GameLogicManager.getInstance().spawnTourUI();

    }

    public void onExecute()
    {
        GameLogicManager.getInstance().rayCastingMode("UI");
    }

    public void onExit()
    {
        GameLogicManager.getInstance().despawnTourUI();
    }

    public string toString()
    {
        return "State Tour Info UI";
    }

  
}
