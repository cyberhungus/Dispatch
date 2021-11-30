using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameLogicManager : MonoBehaviour
{
    // Start is called before the first frame update

   
    [SerializeField] GameObject headPhoneObject;

   

    [SerializeField] GameObject mainMenu;

   

    [SerializeField] GameObject tourInfoUI;

    [SerializeField] LineRenderer nodeLine;

    [SerializeField]
    GameObject tourEndUI;

    [SerializeField]
    GameObject TaxiPrefab;


    //singleton holder 
    static GameLogicManager instance;

    
   
    [SerializeField]
    GameStateManager gameStateManager;

    [SerializeField]
    SoundManager soundManager;

    //right hand script handles the raycasting from the right hand
    RightHandScript rightHand;
    

    GameObject createdHeadPhones;
    GameObject createdMainMenu;
    GameObject createdTourInfoUI;
    GameObject createdTourEndUI;

    [SerializeField]
    GameObject player;

    //variable for outputting to console and other debug features 
    public bool debug = true;
    private bool activeMode=false;

    bool phoneButtonActive = false;
   


    void Start()
    {
        instance = this;
        


        //spawning test plugs 
        if (debug)
        {
            for (int i = 0; i < 5; i++)
            {
                LeanTween.delayedCall(3, delegate () { spawnTaxi(); });
            }
            
        }

        gameStateManager.registerState(new State_PutOnHeadphones());


    }

    public static GameLogicManager getInstance()
    {
        return instance;
    }

    public bool inActiveMode()
    {
        return activeMode;
    }

    public void setActiveMode(bool isActive)
    {
        activeMode = isActive;
    }

    internal GameStateManager getStateManager()
    {
        return gameStateManager;
    }

    public SoundManager getSoundManager()
    {
        return soundManager;
    }

    // Update is called once per frame
    void Update()
    {
        MapManager.GetInstance().ensureTaxiDestinations();
    }

    private void OnGUI()
    {
        if (debug)
        {
           



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
    public void spawnTaxi()
    {
        GameObject createdTaxi = GameObject.Instantiate(TaxiPrefab);
        
        createdTaxi.GetComponent<TaxiScript>().SetDriver(new Driver("Karl", "Hinnerk", 1));

    }

    internal void spawnTourUI()
    {
        createdTourInfoUI = GameObject.Instantiate(tourInfoUI);
        createdTourInfoUI.transform.position = new Vector3(-2, 0, -5);
    }

    internal void despawnTourUI()
    {
        if (createdTourInfoUI != null)
        {
            printDebug("tour info despawned");
            Destroy(createdTourInfoUI);
        }
    }
    internal void spawnTourEndUI()
    {
        createdTourEndUI = GameObject.Instantiate(tourEndUI);
        createdTourEndUI.transform.position = new Vector3(-2, 0, -5);
    }

    internal void despawnTourEndUI()
    {
        if (createdTourEndUI != null)
        {
            printDebug("tour info despawned");
            Destroy(createdTourEndUI);
        }
    }



    internal void spawnHeadphones()
    {
        printDebug("Headphones spawned");
        createdHeadPhones = GameObject.Instantiate(headPhoneObject);
        createdHeadPhones.transform.position = new Vector3(0.56f, -1.2f, -9.8f);
    }

  

    internal void despawnHeadphones()
    {
       if (createdHeadPhones != null)
        {
            printDebug("Headphones despawned");
            Destroy(createdHeadPhones);
        }
    }

    internal void spawnMainMenu()
    {
        createdMainMenu = GameObject.Instantiate(mainMenu);
        createdMainMenu.transform.position = new Vector3(0, 0,0);
        createdMainMenu.transform.Translate(getPlayerForward()+ new Vector3(0,0,10), GameObject.Find("player").transform);
     
        
    }

    internal void activateButton()
    {
        phoneButtonActive = true;
    }

    internal void deactivateButton()
    {
        phoneButtonActive = false;
    }

    public bool getButtonStatus()
    {
        return phoneButtonActive;
    }

    internal void despawnMainMenu()
    {
        if (createdMainMenu!=null)
        {
            Destroy(createdMainMenu);
        }
    }

    public Vector3 getPlayerForward() { return player.transform.forward; }
    public Quaternion getPlayerRotation() { return player.transform.rotation; }

    public Vector3 getPlayerPosition() { return player.transform.position; }
    public Transform getPlayerTransform() { return player.transform; }

    //adds a right hand script to the manager for easy access 
    public void registerRightHand(RightHandScript rhs)
    {
        this.rightHand = rhs;
    }

    //activates/deactives the linerenderer and raycast on the right hand
    public void rayCastingMode(string mode)
    {

        if (rightHand != null)
        {
            if (mode == "MAP")
            {
                rightHand.activateMapMode();
            }

            else if (mode == "UI")
            {
                rightHand.activateUIMode();
            }

            else
            {
                rightHand.deactivateRaycasting();
            }
        }
    }
    
    public void drawLineToNewNode(GameObject newNode)
    {
        nodeLine.positionCount++;
        printDebug("positioncount is now" + nodeLine.positionCount);
        nodeLine.SetPosition(nodeLine.positionCount-1, newNode.transform.position);
    }

    public void resetLine()
    {
        nodeLine.positionCount = 0;
    }


    public void redrawMapLine()
    {
        resetLine();
        if (MapManager.GetInstance().getActiveTour() != null)
        {
            foreach (Location_Interface location in MapManager.GetInstance().getActiveTour().getCurrentNodes())
            {
                nodeLine.positionCount++;
                nodeLine.SetPosition(nodeLine.positionCount - 1, location.GetGameObject().transform.position);
            }
        }
    }


    public void switchActionInputMap(string select)
    {

    }


}
