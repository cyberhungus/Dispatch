using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class HeadphoneScript : MonoBehaviour

    //Headphone model source
    //https://grabcad.com/library/sennheiser-momentum-2-headphones-1
{
    private bool pickedup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedup)
        {
            this.gameObject.transform.position = GameObject.Find("RIGHTHAND").transform.position;
            this.gameObject.transform.rotation = GameObject.Find("RIGHTHAND").transform.rotation;
            if (!GameLogicManager.getInstance().inActiveMode())
            {
                pickedup = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("ontrigger enter in headphone" + GameLogicManager.getInstance().inActiveMode());

        if (other.gameObject.layer == 3 && GameLogicManager.getInstance().inActiveMode())
        {
            
            pickedup = true;

        }
       
    }

    private void OnTriggerStay(Collider other)


    {
       // Debug.Log("ontriggerstay");
       // Debug.Log(other.name);
        if (other.gameObject.layer == 3 && GameLogicManager.getInstance().inActiveMode())
        {
           
            pickedup = true;

        }
        if (other.gameObject.name == "HEAD" && pickedup)
        {
          //  Debug.Log("collision with head");
            GameLogicManager.getInstance().getStateManager().registerState(new State_AcceptCall());
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
