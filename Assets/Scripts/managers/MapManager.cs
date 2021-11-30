using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapManager 
{
    static MapManager instance;
    public bool debug = true;

    Interface_Tour activeTour;

    public Color startColor = new Color(255,0,0);
    public Color endColor = new Color(0, 255, 0);
    public Color highLightedColor = new Color(0, 0, 255);
    public Color normalColor = new Color(255, 255, 0);

    public static MapManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MapManager();
        }
        return instance;
    }

   

    //List of all Locations in the GameWorld
    List<Location_Interface> locations = new List<Location_Interface>();
    //holds all taxis
    List<TaxiScript> taxis = new List<TaxiScript>();

   


    internal Interface_Tour getActiveTour()
    {
        return activeTour;
    }

    public void RegisterLocation(Location_Interface toAdd)
    {
        locations.Add(toAdd);
        printDebug("Registered at MapManager" + toAdd.ToString());
    }


    internal void registerTaxi(TaxiScript taxiScript)
    {
        taxis.Add(taxiScript);
        printDebug("Registered taxi " + taxiScript.ToString());
    }


    public void ensureTaxiDestinations()
    {
        foreach (TaxiScript taxi in taxis)
        {
            //if (taxi.getNextDestination() == null) {
            //    printDebug("Taxi had no destination");
            //    GameObject createdTaxi = taxi.GetGameObject();
            //    Location_Interface random = MapManager.GetInstance().getRandomLocation();
            //    createdTaxi.transform.position = random.GetGameObject().transform.position;
            //    createdTaxi.GetComponent<TaxiScript>().selectNewDestination(random); }
        }
    }

    internal Color getHighlightedColor()
    {
        return highLightedColor;
    }

    internal Color getNormalColor()
    {
        return normalColor;
    }


    //print helper function to toggle output easily 
    void printDebug(string input)
    {
        if (debug)
        {
            Debug.Log(input);
        }
    }
    //filter locations for homes and businesses and return one at random
    internal Location_Interface getRandomLocation()
    {
        Location_Interface place;
        List<Location_Interface> viablelocations = new List<Location_Interface>();
      //  printDebug("location list size is " + locations.Count);

        foreach (Location_Interface loc in locations)
        {
            if (loc.getType() == "HOUSE" || loc.getType() == "BUSINESS")
            {
               // printDebug("added to list" + loc.getName());
                viablelocations.Add(loc);
            }
        }
      //  printDebug("Listsize is " + viablelocations.Count);
        int selection = UnityEngine.Random.Range(0, viablelocations.Count);
      //  printDebug("Listsize is " + locations.Count + " Selection is " + selection);
        place = viablelocations[selection];
        
        while (place == null)
        {
           place = viablelocations[selection];
        }
        printDebug(place.getName());
        return place;

    }

    internal void addNodeToCurrentTour(Location_Interface place)
    {
       if (activeTour != null)
        {
            activeTour.addNode(place);
            printDebug("Added node to tour" + place.getName());
            printDebug("current nodes " + activeTour.getCurrentNodesToString());
           //makeOnlyObjectsInTourVisible();

            
        }
    }


    public void highlightNode(GameObject toColor)
    {
        foreach (Location_Interface location in locations)
        {
            if (location.GetGameObject().Equals(toColor))
            {
                location.highlight();
                
            }
        }
    }

    public void deleteLastNodeAndUpdateMap()
    {
        printDebug("Deleting last node");

        if (activeTour != null)
        {
            activeTour.deleteLastNode();
        }
    }




    public void SetActiveTour(Interface_Tour newTour)
    {
        activeTour = newTour;

        
        makeOnlyObjectsInTourVisible();
        InfoWallManager.getInstance().updateWallText();
    }

    public void makeOnlyObjectsInTourVisible()
    {
        if (activeTour != null)
        {
            foreach (Location_Interface loc in locations)
            { 
            if (loc.getName() == activeTour.getFromLocation().getName() || loc.getName() == activeTour.getTargetLocation().getName())
                {
                    loc.setVisible(true);
                    if (loc.getName() == activeTour.getFromLocation().getName())
                    {
                        loc.setColor(startColor);
                    }
                    if (loc.getName() == activeTour.getTargetLocation().getName())
                    {
                        loc.setColor(endColor);
                    }
                }
                else
                {

                    loc.setVisible(false);
                    //foreach (Location_Interface currentLoc in activeTour.getCurrentNodes())
                    //{
                    //    if (loc.getName() == currentLoc.getName())
                    //    {
                    //        loc.setVisible(true);
                    //    }
                    //    else
                    //    {
                    //        loc.setVisible(false);
                    //    }
                    //}


                   
                }
            
            }
           
        }
    }

}
