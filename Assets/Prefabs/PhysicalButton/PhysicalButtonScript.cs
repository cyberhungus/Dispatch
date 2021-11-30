using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class PhysicalButtonScript : MonoBehaviour
{



    // Start is called before the first frame update

    [SerializeField]
    GameObject button;


    public bool debug = true;


    Event onButtonPressed;
    
    // Start is called before the first frame update
    void Start()
    {


        //iterate through the buttons children to find the button object in order to animate it 
        

        
        printDebug(button.ToString());

      

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider collision)
    {
        printDebug("ontriggerenter in button");
        printDebug(collision.name);
        if (collision.gameObject.layer == 3 && GameLogicManager.getInstance().getButtonStatus())
        {
            LeanTween.moveLocalY(button, -0.01f, 0.1f).setOnComplete(delegate ()
            {
                MapManager.GetInstance().SetActiveTour(new Tour_Random());
                GameLogicManager.getInstance().getStateManager().registerState(new State_TourInfoUI());
                LeanTween.moveLocalY(button, +0.01f, 0.1f);
            });



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
