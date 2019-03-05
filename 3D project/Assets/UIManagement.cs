using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    // text to show the message
    public Text text;
    // Image to fillAmount
    public Image imLife;
    // public Image bloods;
    private bool paused = false;
    public void UpdateLife(float calculateLife)
    {
        // define a value between 0 and 100
        calculateLife = Mathf.Clamp(calculateLife, 0, 100);
        // indicate the amount 
        imLife.fillAmount = calculateLife / 100;
        // show value in UIText
        text.text = "LIFE" + " " + calculateLife + "%";
        if (calculateLife == 0)
        {
            // call the method "Finish" which is locate in the class of GameOver
            GameObject.FindWithTag("PanelGameOver").GetComponent<GamesOver>().Finish();
            // call the animation that manage the dead of the player
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("dead");
            // stop the animation, in order to avoid some errors, or warning
            StartCoroutine(Stop2PlayAnimations());
 
        }
    }
    void OnPauseGame()
    {
        paused = true; // pause de game
    }
    IEnumerator Stop2PlayAnimations()
    {
        yield return new WaitForSeconds(3f);
        OnPauseGame();
        Time.timeScale = 0; // stop the time
    }

}
