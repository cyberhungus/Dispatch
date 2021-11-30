using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(BoxCollider))]
public class TXPlugScript : MonoBehaviour
{
   public bool debug = true;
    Location_Interface place;

    public string Name;
    public string Description;
    public bool isBusiness;
    public bool isHome;

 public  List<GameObject> adjacentNodes = new List<GameObject>();


   TextMeshProUGUI textfield;
    TextMeshProUGUI descfield;
   public GameObject textDisplay;
    // Start is called before the first frame update
    public Material mat2;

    

    void Start()
    {
        textfield = textDisplay.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        descfield = textDisplay.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        
        if (isBusiness || isHome)
        {
            
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            textfield.text = this.Name;
            descfield.text = this.Description;

            if (isHome && !isBusiness)
            {
                place = new Location_House(Name, Description, this.gameObject);
                MapManager.GetInstance().RegisterLocation(place);
            }
            if (!isHome && isBusiness)
            {
                place = new Location_Business(Name, Description, this.gameObject);
                MapManager.GetInstance().RegisterLocation(place);
            }

        }
       else
        {
         //   Debug.Log(this.gameObject.GetComponent<MeshRenderer>().ToString());
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            textfield.gameObject.transform.parent.gameObject.SetActive(false);
            place = new Location_Street(Name, Description, this.gameObject);
            MapManager.GetInstance().RegisterLocation(place);
        }


        

    }

    internal Location_Interface getPlace()
    {
        return place;
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.transform.LookAt(GameObject.Find("PLAYER").transform.position);
        textDisplay.transform.Rotate(0, 180, 0);
    }

    public void setVisible(bool isVisible)
    {
        if (isVisible)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            
            this.GetComponent<Collider>().enabled = true;

            if (this.isBusiness || this.isHome)
            {
                textDisplay.SetActive(true);
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            textDisplay.SetActive(false);
            this.GetComponent<Collider>().enabled = false;
        }
    }




    private void OnTriggerEnter(Collider collision)
    {
       printDebug("txplug ontriggerenter ");
        printDebug(collision.gameObject.name);
        if (collision.gameObject.layer == 5 )
        {
           foreach (GameObject GO in adjacentNodes)
            {
                GO.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            }



        }


    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject GO in adjacentNodes)
        {
            GO.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
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


}
