using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MapConnect : Interface_State
{
    public void onEnter()
    {
        Debug.Log("Entered MapConnect state");
        GameLogicManager.getInstance().rayCastingMode("MAP");
        //MapManager.GetInstance().SetActiveTour(new Tour_Random());
    }

    public void onExecute()
    {
       // GameLogicManager.getInstance().rayCastingMode("MAP");
       if(MapManager.GetInstance().getActiveTour().checkIfCompleted())
        {
            GameLogicManager.getInstance().getStateManager().registerState(new State_TourEndUI());
        }
    }

    public void onExit()
    {
        Debug.Log("Exited MapConnect state");
        GameLogicManager.getInstance().resetLine();
    }

    public string toString()
    {
        return "State Map Connect";
    }
}
