using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiScript : MonoBehaviour
{

    bool isOnTour;

    int seats = 3;

    float speed = 70000;

    float movementState = 0;

    Driver driver;

    Location_Interface nextDestination;
    Location_Interface prevDestination;

    //distance to target that is considered "reaching the target"
    float targetDistance = 0.00005f;


    // Start is called before the first frame update
    void Start()
    {
        MapManager.GetInstance().registerTaxi(this);
        nextDestination = GameObject.Find("Map Itzehoe").transform.Find("Reiterhof").GetComponent<TXPlugScript>().getPlace();
    }

    void Update()
    {
        if (nextDestination == null)
        {
            nextDestination = GameObject.Find("Krankenhaus").GetComponent<TXPlugScript>().getPlace();
        }
    

}

    private void FixedUpdate()
    {
        moveObject(nextDestination.GetGameObject().transform.position);


    }

    public void selectNewDestination()
    {
        prevDestination = nextDestination;
        int selection = UnityEngine.Random.Range(0, nextDestination.getAdjacentNodes().Count);
        Debug.Log("taxi new dest selection was " + selection);
        if (nextDestination.getAdjacentNodes().Count > 1)
        {
            if (nextDestination.getAdjacentNodes()[selection].GetComponent<TXPlugScript>().getPlace() == prevDestination)
            {
                Debug.Log("found the same destination pls, chose another one");
                selection += 1;
            }
        }
        nextDestination = nextDestination.getAdjacentNodes()[selection].GetComponent<TXPlugScript>().getPlace();
        movementState = 0;
        
    }

    public void moveObject(Vector3 position)
    {
        Vector3 ownPosition = GetGameObject().transform.position;
        //Vector3 targetPosition = position;
        //Vector3 toMove = targetPosition - ownPosition;
        //Vector3.Normalize(toMove);
        //toMove = toMove / speed;
        //ownPosition += toMove;
        //GetGameObject().transform.position = ownPosition;

        movementState += 0.001f;

       Vector3 resultLerp = Vector3.Lerp(ownPosition, position, movementState);

        GetGameObject().transform.position = resultLerp;
        if (Vector3.Distance(ownPosition, position) < 0.01)
        {
            Debug.Log("reached target " + nextDestination.getName() +"with distance "+ Vector3.Distance(ownPosition, position));
            selectNewDestination();
            Debug.Log("new target is " + nextDestination.getName());
        }
    

    }

        public GameObject GetGameObject()
    {
        return this.gameObject;

    }

    public Location_Interface getNextDestination()
    {
        return nextDestination;
    }

    public Vector3 getPosition()
    {
       return GetGameObject().transform.position;
    }

    public float getDistanceToDestination()
    {
        return Vector3.Distance(getPosition(), nextDestination.GetGameObject().transform.position);
    }


    public Driver GetDriver()
    {
        return driver;
    }

    public void SetDriver(Driver newDriver)
    {
        this.driver = newDriver;
        newDriver.assignTaxi(this);
    }
}
