using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour_Random : Interface_Tour
{
    Location_Interface origin;
    Location_Interface destination;
    bool originConnected;
    bool destinationConnected;

    List<Location_Interface> nodes = new List<Location_Interface>();


    string[] tourText = { "Hello, I am a random person","Please transport me from", "to" };
    string finishText = "Thank you for the ride";

    public Tour_Random()
    {
        origin = MapManager.GetInstance().getRandomLocation();
        destination = MapManager.GetInstance().getRandomLocation(); 
    }


    public Location_Interface getFromLocation()
    {
        return origin;
    }

    public Location_Interface getTargetLocation()
    {
        return destination;
    }

    public void setFromLocation(Location_Interface origin)
    {
        
    }

    public void setTargetLocation(Location_Interface target)
    {
        
    }

  public void addNode(Location_Interface newLocation)
    {
        bool isDouble = false;
        bool isAdjacentToLastNode = false;
        foreach (Location_Interface node in nodes)
        {
            if (newLocation.Equals(node))
            {
                isDouble = true;
            }
        }
        

        if (nodes.Count > 0)
        {
            Debug.Log("las node in tour:" + getLastNodeInTour().getName() + "with " + getLastNodeInTour().getAdjacentNodes().Count +" adjacent nodes");
            if (getLastNodeInTour().getAdjacentNodes().Count > 1)
            {
                foreach (GameObject node in getLastNodeInTour().getAdjacentNodes())
                {
                    if (node.GetComponent<TXPlugScript>().getPlace().Equals(newLocation))
                    {
                        isAdjacentToLastNode = true;
                    }
                }
            }
            else
            {
                isAdjacentToLastNode = true;
            }
        }
        else
        {
            Debug.Log("no nodes in tour");
            isAdjacentToLastNode = true;
        }

        Debug.Log("adjacent to last node " + isAdjacentToLastNode);

        if (!isDouble && isAdjacentToLastNode)
        {
            nodes.Add(newLocation);
            Debug.Log("Added to nodes: " + newLocation.getName());
            foreach (GameObject newNode in newLocation.getAdjacentNodes())
            {
                newNode.GetComponent<TXPlugScript>().setVisible(true);
            }
            GameLogicManager.getInstance().drawLineToNewNode(newLocation.GetGameObject());
        }
        else
        {
            Debug.Log("node was double");
        }

      
    }

    public override string ToString()
    {
        return "Tour from " + origin.ToString() + " to " + destination.ToString();
    }

    public string getTextAtIndex(int index)
    {
        return tourText[index];
    }

    public List<Location_Interface> getCurrentNodes()
    {
        return nodes;
    }

    //
    public string getCurrentNodesToString()
    {
        string returnString = "";
        foreach (Location_Interface loc in nodes)
        {
            returnString += loc.getName();

        }
        return returnString;
    }

    public Location_Interface getLastNodeInTour()
    {
        return nodes[nodes.Count-1];
    }

    public bool checkIfCompleted()
    {
        foreach (Location_Interface loc in nodes)
        {
            if (loc.Equals(origin))
            {
                originConnected = true;
            }
            if (loc.Equals(destination))
            {
                destinationConnected = true;
            }

        }

        return originConnected && destinationConnected;
    }

    public string getFinishedText()
    {
        return finishText;
    }

    public void deleteLastNode()
    {
        if (getCurrentNodes().Count > 1)
        {

            getLastNodeInTour().setVisible(false);
            foreach (GameObject adjacentLoc in getLastNodeInTour().getAdjacentNodes())
            {
                if (adjacentLoc.GetComponent<TXPlugScript>().getPlace().getName() != origin.getName() && adjacentLoc.GetComponent<TXPlugScript>().getPlace().getName() != destination.getName())
                {
                    adjacentLoc.GetComponent<TXPlugScript>().getPlace().setVisible(false);
                }
            }
            nodes.Remove(getLastNodeInTour());
            foreach (GameObject adjacentLoc in getLastNodeInTour().getAdjacentNodes())
            {
                adjacentLoc.GetComponent<TXPlugScript>().getPlace().setVisible(true);
            }
            GameLogicManager.getInstance().redrawMapLine();
        }
        else if (getCurrentNodes().Count == 1)
        {
            
            foreach (GameObject adjacentLoc in getLastNodeInTour().getAdjacentNodes())
            {

                if (adjacentLoc.GetComponent<TXPlugScript>().getPlace().getName() != origin.getName() && adjacentLoc.GetComponent<TXPlugScript>().getPlace().getName() != destination.getName())
                {
                    adjacentLoc.GetComponent<TXPlugScript>().getPlace().setVisible(false);
                }
            }
            nodes.Remove(getLastNodeInTour());
        }

    }
}
