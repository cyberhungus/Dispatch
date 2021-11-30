using System.Collections.Generic;
using UnityEngine;

class Location_Street : Location_Interface
{
    string name, description;

    GameObject gameObject;


    public Location_Street(string name, string description, GameObject gameObject)
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
        return "STREET";
    }

    public void highlight()
    {
        LeanTween.color(gameObject.transform.GetChild(0).gameObject, MapManager.GetInstance().getHighlightedColor(), 0.01f).setOnComplete(delegate ()
        {
            LeanTween.color(gameObject.transform.GetChild(0).gameObject, MapManager.GetInstance().getNormalColor(), 0.01f);
        });
    }

    public void setColor(Color c)
    {
        GetGameObject().transform.GetChild(0).GetComponent<MeshRenderer>().material.color = c;
    }

    public void setVisible(bool status)
    {
        GetGameObject().GetComponent<TXPlugScript>().setVisible(status);
    }

    public string ToString()
    {
        return "STREET:" + this.name + "-" + this.description;
    }


    



}