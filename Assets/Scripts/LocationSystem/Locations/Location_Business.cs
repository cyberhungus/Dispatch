using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location_Business : Location_Interface
{
    string name, description;

    GameObject gameObject;


    public Location_Business(string name, string description, GameObject gameObject)
    {
        this.name = name;
        this.description = description;
        this.gameObject = gameObject;
    }

    public List<GameObject> getAdjacentNodes()
    {
        return this.gameObject.GetComponent<TXPlugScript>().adjacentNodes;
    }

    public string getDescription()
    {
        return description;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public string getName()
    {
        return name;
    }

    public string getType()
    {
        return "BUSINESS";
    }

    public string ToString()
    {
        return "BUSINESS:" + this.name + "-" + this.description;
    }
    public void setVisible(bool status)
    {
        GetGameObject().GetComponent<TXPlugScript>().setVisible(status);
    }
    public void setColor(Color c)
    {
        GetGameObject().transform.GetChild(0).GetComponent<MeshRenderer>().material.color = c;
    }
    public void highlight()
    {
        LeanTween.color(gameObject.transform.GetChild(0).gameObject, MapManager.GetInstance().getHighlightedColor(), 0.01f).setOnComplete(delegate ()
        {
            LeanTween.color(gameObject.transform.GetChild(0).gameObject, MapManager.GetInstance().getNormalColor(), 0.01f);
        });
    }
}
