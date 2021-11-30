using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interface_State
{
    public void onEnter();

    public void onExecute();

    public void onExit();

    public string toString(); 



}
