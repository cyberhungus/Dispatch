using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoWallManager : MonoBehaviour
{

    static InfoWallManager instance;
    public GameObject fromTextField;
    public GameObject toTextField;

    TMP_Text fromText;
    TMP_Text toText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        fromText = fromTextField.GetComponent<TMP_Text>();
        toText = toTextField.GetComponent<TMP_Text>();



    }


    public static InfoWallManager getInstance() { return instance; }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void updateWallText()
    {

        Interface_Tour currentTour = MapManager.GetInstance().getActiveTour();
        fromText.text = currentTour.getFromLocation().getName();
        toText.text = currentTour.getTargetLocation().getName();
    }
}
