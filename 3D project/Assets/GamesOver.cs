using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamesOver : MonoBehaviour
{
    public Text TheGameIsOver;
    // Start is called before the first frame update
    void Start()
    {
        TheGameIsOver.text = " ";
    }

    public void Finish()
    {
        TheGameIsOver.text = "GAME OVER";
       //You cannot do a Find(object) on something that is already deactivated
    }
   
}
