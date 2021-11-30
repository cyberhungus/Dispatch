using System.Collections.Generic;


public interface Interface_Tour
{
    Location_Interface getFromLocation();
    Location_Interface getTargetLocation();

    void setFromLocation(Location_Interface origin);

    void setTargetLocation(Location_Interface target);

    string ToString();

    void addNode(Location_Interface newLocation);


    string getTextAtIndex(int index);

    string getFinishedText();

    string getCurrentNodesToString();

    List<Location_Interface> getCurrentNodes();

    bool checkIfCompleted();
    void deleteLastNode();
}