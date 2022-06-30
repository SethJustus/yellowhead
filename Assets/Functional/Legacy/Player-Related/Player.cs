using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool tryingToTalk;
    public Dialogue_Manager manager;
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)&&tryingToTalk == false)
        {
            tryingToTalk = true;
            //Debug.Log("Trying to talk");
        }else{
            tryingToTalk = false;
            //Debug.Log("No longer trying");
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(manager.displaying == true)
            {
                manager.DisplayNextSentence();
            }
        }
    }
}
