using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPauseScipt : MonoBehaviour
{
    string longerTime;

    public Text privateScoreTxt;
    public Text currentScoreTxt;
    public Text highScoreTxt;
    public Text currentCoinsTxt;
    public Text highCoinsTxt;
    public Text highTimeSurvivedTxt;
    public int seconds;
    public int minutes;
    public int hours;
   
    void Update()
    {
        

        GameObject.Find("Player").GetComponent<CubeScript>().enabled = false;
        longerTime = string.Format("{0:00}:{1:00}:{2:00}", PlayerPrefs.GetInt("highHours"), PlayerPrefs.GetInt("highMinutes"), PlayerPrefs.GetInt("highSeconds"));

        /*Current*/
        currentScoreTxt.text = "" + (int)GameObject.Find("Player").GetComponent<CubeScript>().score;
        currentCoinsTxt.text = "" + GameObject.Find("Player").GetComponent<PlayerTrriger>().coinsCounter;

        /*High-Score*/
        highScoreTxt.text = "" + PlayerPrefs.GetInt("highScore");
        highCoinsTxt.text = "" + PlayerPrefs.GetInt("mostCoins");
        highTimeSurvivedTxt.text = longerTime;

        privateScoreTxt.text = currentScoreTxt.text;

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            GameObject.Find("Player").GetComponent<CubeScript>().enabled = true;
            GameObject.Find("Player").GetComponent<CubeScript>().fermerPause();
        }
    }

    public void fermerPauseWithButton()
    {
        GameObject.Find("Player").GetComponent<CubeScript>().enabled = true;
        GameObject.Find("Player").GetComponent<CubeScript>().fermerPause();
    }
}
