using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightHandScript : MonoBehaviour
{

    LineRenderer lineRenderer;

    bool mapModeActive;
    bool UIModeActive;

    int debugCounter = 0;

    // Start is called before the first frame update
    void Start()
    {


        lineRenderer = this.transform.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.transform.position);
        GameLogicManager.getInstance().registerRightHand(this);
    }

    // Update is called once per frame
    void Update()
    {
        



    }


   public void activateMapMode()
    {
        mapModeActive = true;
        UIModeActive = false;
    }

    public void activateUIMode()
    {
        mapModeActive = false;
        UIModeActive = true;
    }

    public void deactivateRaycasting()
    {
        mapModeActive = false;
        UIModeActive = false;
    }


    void FixedUpdate()
    {
        debugCounter++;
        if (mapModeActive) {
          //  print("mapmodeactive at cycle" + debugCounter);
            castLine();
            rayCastforMap(); }
        
        if (UIModeActive) {
          //  print("uimodeactive at cycle" + debugCounter);
            castLine();
            rayCastforUI(); }
        if (!mapModeActive && !UIModeActive)
        {
           // print("raycaster disabled at cycle" + debugCounter);
            castHiddenLine();
        }
    }
    //casts a line that is invisible to the player, as errors occured with setactive

    private void castHiddenLine()
    {
        lineRenderer.SetPosition(0, new Vector3(100,100,100));
        
        lineRenderer.SetPosition(1, new Vector3(100, 100, 100));
    }

    //draws a line from the right controller forward
    void castLine()
    {
        
        lineRenderer.SetPosition(0, this.transform.position);
        Vector3 endPoint = this.transform.position + (this.transform.up * -1) * 10;
        lineRenderer.SetPosition(1, endPoint);
    }

    //raycast, for map targets
    void rayCastforMap()
    {
        //mapmarkers are in layer 7, the raycast shall only "see" those
        int layerMask = 1 << 7;
        //stores information about the last object hit by the raycast 
        RaycastHit hit;
        //mathematical trickery to get the line to where we want it 
        Vector3 endPoint = this.transform.position + (this.transform.up * -1) * 10000000;
        if (Physics.Raycast(transform.position, endPoint, out hit, 10000000, layerMask: layerMask))
        {

            if (hit.collider != null)
            {
            //    print("hit collider " + hit.collider.gameObject.name);
            //    print("child0 " + hit.collider.gameObject.transform.GetChild(0));

                if (GameLogicManager.getInstance().inActiveMode())
                {
                    MapManager.GetInstance().addNodeToCurrentTour(hit.collider.gameObject.GetComponent<TXPlugScript>().getPlace());
                }

                if (hit.collider.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>() != null)
                {
                    MapManager.GetInstance().highlightNode(hit.collider.gameObject);


                    
                   
                }


            }
          
        }
    }
    void rayCastforUI()
    {
        int layerMask = 1 << 5;
        RaycastHit hit;
        Vector3 endPoint = this.transform.position + (this.transform.up * -1) * 100;
        if (Physics.Raycast(transform.position, endPoint, out hit, 10000000, layerMask: layerMask))
        {

            if (hit.collider != null)
            {
                print("hit collider " + hit.collider.gameObject.name);
                print("child0 " + hit.collider.gameObject.transform.GetChild(0));

                if (hit.collider.gameObject.GetComponent<Image>() != null)
                {
                    print("hit object had image");
                    hit.collider.gameObject.GetComponent<Image>().color = new Color(100, 100, 100);

                }



               if (GameLogicManager.getInstance().inActiveMode())
                {
                    if (hit.collider.gameObject.name == "ForwardButton")
                    {
                        print("moving to new state");
                        GameLogicManager.getInstance().getStateManager().registerState(new State_MapConnect());

                    }
                    if (hit.collider.gameObject.name == "ForwardButtonAfterTour")
                    {
                        print("moving to new state");
                        GameLogicManager.getInstance().getStateManager().registerState(new State_AcceptCall());

                    }
                    if (hit.collider.gameObject.name == "BackwardButton")
                    {
                        print("backbutton hit");

                    }
                }



            }

        }
    }
}

