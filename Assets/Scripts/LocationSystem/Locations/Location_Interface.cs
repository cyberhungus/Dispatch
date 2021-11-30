using UnityEngine;
using System.Collections.Generic;

public interface Location_Interface
{
    
    string getName();
    
    string getDescription();
    string getType();

    GameObject GetGameObject();

    string ToString();

    List<GameObject> getAdjacentNodes();

    void setVisible(bool status);

    void setColor(Color c);
    void highlight();
}