using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLoseManager : MonoBehaviour
{
    string longerTime;

    public Text privateScoreTxt;
    public Text currentScoreTxt;
    public Text highScoreTxt;
    public Text currentCoinsTxt;
    public Text highCoinsTxt;
    public Text highTimeSurvivedTxt;
    //Pour currentTimeSurvivedTxt go check PlayerCollision.cs.73 et GroundCollision.cs.74


    void Update()
    {
        longerTime = string.Format("{0:00}:{1:00}:{2:00}", PlayerPrefs.GetInt("highHours"), PlayerPrefs.GetInt("highMinutes"), PlayerPrefs.GetInt("highSeconds"));

        /*Current*/
        currentScoreTxt.text = "" + (int)GameObject.Find("Player").GetComponent<CubeScript>().score;
        currentCoinsTxt.text = "" + GameObject.Find("Player").GetComponent<PlayerTrriger>().coinsCounter;
        
        
        /*High-Score*/
        highScoreTxt.text = "" + PlayerPrefs.GetInt("highScore");
        highCoinsTxt.text = "" + PlayerPrefs.GetInt("mostCoins");
        highTimeSurvivedTxt.text = longerTime;

        privateScoreTxt.text = currentScoreTxt.text;
    }
}
