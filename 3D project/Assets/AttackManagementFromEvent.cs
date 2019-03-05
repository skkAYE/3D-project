//@ Audain Desrosiers, PHD in computer sciences
// computer vision
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManagementFromEvent: MonoBehaviour
{
    // this code will help you to manage the attack event in the animation
    //
    // define the number of life for the FPSController or the Alien
    public float life = 100.00f;
    // set the dammage values
    float dammages = 10.00f;
    // this is used in a canvas groupe, to make a fade in (blood screen)
    float valuesAlpha = 1.0f;
    private void Start()
    {
        // at the beginning put all life at their maximum values
        // life FPSController
        GameObject.Find("FpsUiPanel").GetComponent<UIManagement>().UpdateLife(life);
        // life alien
        GameObject.Find("AlienUiPanel").GetComponent<UIManagement>().UpdateLife(life);
    }
    // this method will be placed on the event of the selected animation
    // explanation:
    //for example :
    // 1- select the "mutant @ BoxingR" or "mutant @BoxingD" animation by clicking on it
    // 2- Click on the "Animation" label
    // 3- click on "EVENT"
    // 4- Starts the animation and selects a specific action with the mouse, for example the beginning of the hit
    // 5- click on the small "+" on the left
    // 6 add the method Dammages ()
    public float Dammages()
    {
       life = life - dammages;
       // Find the UI, then call Dammage methode to update the correspondant UI
        //Life player
        GameObject.Find("FpsUiPanel").GetComponent<UIManagement>().UpdateLife(life);
        // this code is used to control the blood screen little by little
        GameObject.Find("PanelBloods").GetComponent<CanvasGroup>().alpha = valuesAlpha-(life/ 100);
        // life alien
        // GameObject.Find("AlienUiPanel").GetComponent<UIManagement>().UpdateLife(life);
        return life;
    }
}
