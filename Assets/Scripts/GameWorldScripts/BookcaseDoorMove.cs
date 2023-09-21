using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookcaseDoorMove : MonoBehaviour
{
    GameObject lever1;
    GameObject lever2;
    bool opened = false;

    private void Start()
    {
        lever1 = GameObject.Find("LeverObj1");
        lever2 = GameObject.Find("LeverObj2");
    }

    public void updated()
    {
        if((lever1.GetComponent<LeverActivate>().Activated == false || lever2.GetComponent<LeverActivate>().Activated == false) && opened == true)
        {
            opened = false;
            this.GetComponent<Animator>().SetTrigger("Trigger");
        }
            
        if ((lever1.GetComponent<LeverActivate>().Activated == true && lever2.GetComponent<LeverActivate>().Activated == true) && opened == false)
        {
            opened = true;
            this.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
}
