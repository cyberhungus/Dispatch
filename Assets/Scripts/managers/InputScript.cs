using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    public bool debug;
    public float triggerThreshold = 0.8f;

    private int counter = 0;
    private DateTime currentTime;
    private DateTime loopTime;
    //is the delete action ready (i.e. ´has it been long enough since the last deletion)
    private bool deleteActionReady;
    
    //Delay for delete
    private double deleteActionDelay=1000;

    public void Move(InputAction.CallbackContext context)
    {
        GameObject test = GameObject.Find("test");
        Debug.Log(context.valueType.ToString());
        test.transform.position = context.ReadValue<Vector3>();
    }

    //handles wether the player is in active mode or not 
    public void modeHandler(InputAction.CallbackContext context)
    {
        //counter++;
     //   printDebug("entermod" + counter);
        float inptval = (float)context.ReadValue<float>();

       // printDebug("input value was " + inptval);
        if (inptval == 0)
        {
       //     printDebug("0 null 0 " + counter);
            return;

        }
        
        if ((float)inptval > triggerThreshold )
        {
        
            GameLogicManager.getInstance().setActiveMode(true);
       //     printDebug("active mode true with " + inptval + "  -" + counter);
            return;
        }
        else 
        {
           
            GameLogicManager.getInstance().setActiveMode(false);
           // printDebug("active mode false with "+inptval+"  -" + counter);
            return;
        }
        

      
    }

    public void deletelastNode(InputAction.CallbackContext context)
    {
        

        printDebug("deletion: input value was " +counter);
        if (deleteActionReady)
        {
            MapManager.GetInstance().deleteLastNodeAndUpdateMap();
            printDebug("delete true with " + counter);
            loopTime = DateTime.Now;


        }
        else
        {
            printDebug("deletion not ready " + counter);
        }

    }

    void Update()
    {
        if (loopTime == null)
        {
            loopTime = DateTime.Now;
        }
        counter++;
        currentTime = System.DateTime.Now;
        if ((currentTime - loopTime).TotalMilliseconds >= deleteActionDelay)
        {
            deleteActionReady = true;
            
        }
        else
        {
            deleteActionReady = false;
        }
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

