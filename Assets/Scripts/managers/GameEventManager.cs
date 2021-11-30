using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{


    static GameEventManager instance;


    public Action onConnectConversationAction;

    public Action onConnectCallerAction;

    public Action onDisconnectCallAccidentAction;

    public Action onDisconnectCallSuccessAction;

    public Action onCreateCallAction;


    public Event connectConversationEvent;

    public Event connectCallerEvent;

    public Event disconnectCallAccidentEvent;

    public Event disconnectCallSuccessEvent;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameEventManager getInstance()
    {
        return instance;
    }
}
