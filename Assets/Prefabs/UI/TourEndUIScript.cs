using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TourEndUIScript : MonoBehaviour
{
    
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
       
        text = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>();


        Interface_Tour currentTour = MapManager.GetInstance().getActiveTour();
        text.text = currentTour.getFinishedText();
    }

    // Update is called once per frame
    void Update()
    {
      //  Vector3 endPoint = GameLogicManager.getInstance().getPlayerPosition() + GameLogicManager.getInstance().getPlayerForward() * 2;
      //  this.gameObject.transform.position = endPoint;
        //this.gameObject.transform.LookAt(GameLogicManager.getInstance().getPlayerPosition());
    }

    private void FixedUpdate()
    {

    }
}
