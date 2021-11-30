using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TourStartUIScript : MonoBehaviour
{
    TMP_Text header;
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        header = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        text = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();


        Interface_Tour currentTour = MapManager.GetInstance().getActiveTour();
        text.text = currentTour.getTextAtIndex(0) +" "+ currentTour.getTextAtIndex(1) + " " + currentTour.getFromLocation().getName() + " " + currentTour.getTextAtIndex(2) + " " + currentTour.getTargetLocation().getName();
        header.text = "New Tour Assignment";
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 endPoint = GameLogicManager.getInstance().getPlayerPosition() + GameLogicManager.getInstance().getPlayerForward() * 2;
       // this.gameObject.transform.position = endPoint;
     //   this.gameObject.transform.LookAt(GameLogicManager.getInstance().getPlayerPosition());
    }

    private void FixedUpdate()
    {
       
    }
}
