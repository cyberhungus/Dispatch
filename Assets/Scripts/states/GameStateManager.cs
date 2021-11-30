using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    Interface_State currentState;
    Interface_State lastState;

    public bool debug = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //execute whatever function is in the current state; 
        currentState.onExecute(); 
    }

    public void registerState(Interface_State newState)
    {

        
        //if there is a state currently active, please end it 
        if (currentState != null) {
            printDebug("RegisterState, current is " + currentState.toString() + " new is " + newState.toString());
            currentState.onExit();
        }
        else
        {
            printDebug("RegisterState, new is " + newState.toString());
        }
        //store the current state into the laststate variable so it can be retrieved (useful for pausing) 
        lastState = currentState;
        //make the specified state from the arguments into the currentstate
        currentState = newState;
        //execute the onenter function 
        currentState.onEnter(); 
    }

    public void retrieveState()
    {
        registerState(lastState);
    }

    //print helper function to toggle output easily 
    void printDebug(string input)
    {
        if (debug)
        {
            Debug.Log(input);
        }
    }
}
